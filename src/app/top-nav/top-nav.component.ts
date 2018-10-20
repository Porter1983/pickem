import { Component, OnInit } from '@angular/core';
import { Router } from '../../../node_modules/@angular/router';
import { Observable, throwError, forkJoin } from 'rxjs';
import { of } from 'rxjs/observable/of';
import { interval } from "rxjs/internal/observable/interval";
import { timer } from "rxjs/internal/observable/timer";
import { startWith, switchMap, debounceTime, map, debounce, retryWhen, delayWhen, tap, delay } from "rxjs/operators";

import { environment } from '../../environments/environment';
import { VERSION } from '../../environments/version';

import { StatusService } from '../sub-system/services/status.service';
import { UserService } from '../sub-system/services/user.service';
import { Player } from '../sub-system/models/api/player';
import { LeagueScoreboard } from '../sub-system/models/api/league-scoreboard';
import { PlayerScoreboard } from '../sub-system/models/api/player-scoreboard';
import { WeekScoreboard } from '../sub-system/models/api/week-scoreboard';
import { LeagueService } from '../sub-system/services/league.service';
import { LoggerService } from '../sub-system/services//logger.service';

import { QueueingSubject } from 'queueing-subject'
import websocketConnect from 'rxjs-websockets'


class StatusValue
{
  FieldValue: string;
  FieldName: string;
}

class Scoreboards
{
  leagueScoreboard: LeagueScoreboard;
  playerScoreboard: PlayerScoreboard; 
  weekScoreboard: WeekScoreboard;
}


@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent implements OnInit {

  isCollapsed = true;
  refreshInProcess = false;
  StatusValues: StatusValue[] = [];
  private _socketSubscription;

  constructor(public statusService: StatusService, public leagueService: LeagueService, private router: Router, private userService: UserService, private logger: LoggerService, ) { }

  ngOnInit() {

    // get server status values, then build them plus this one.
    this.statusService.readPickEmStatus()
      .subscribe(pickemeStatus => 
        {
          //statusValues.push(new StatusValue(FieldName: "Database", FieldValue: nickServerStatus.database))
          this.StatusValues.push({ FieldName: "Authenticated User", FieldValue: pickemeStatus.authenticatedUserName });
          this.StatusValues.push({ FieldName: "Database", FieldValue: pickemeStatus.database });
          this.StatusValues.push({ FieldName: "Database Host", FieldValue: pickemeStatus.databaseHost });
          this.StatusValues.push({ FieldName: "Service Product", FieldValue: pickemeStatus.product });
          this.StatusValues.push({ FieldName: "Service Version", FieldValue: pickemeStatus.productVersion });
          this.StatusValues.push({ FieldName: "Service Runtime Environment", FieldValue: pickemeStatus.runtimeEnvironment });
          this.StatusValues.push({ FieldName: "Web to Service REST URL", FieldValue: environment.pickemRestServerBaseUrl });
          this.StatusValues.push({ FieldName: "Web Runtime Environment", FieldValue: ( environment.production ? "Production" : "Non-Prod" ) });
          this.StatusValues.push({ FieldName: "Web Version", FieldValue: VERSION.version });
        }
      )

    const socketInput = new QueueingSubject<string>()
    const { messages, connectionStatus } = websocketConnect(environment.pickemWebSocketUrl, socketInput);

    // the connectionStatus stream will provides the current number of websocket
    // connections immediately to each new observer and updates as it changes
    const connectionStatusSubscription = connectionStatus
      .subscribe(numberConnected => {
        console.log('number of connected websockets:', numberConnected)
      });

   const pipedMessages = messages
      .pipe(
        retryWhen(errors => 
          errors.pipe(
            tap(error => this.logger.debug("Socket error. Delayed retry. Error: " + error)),
            delay(10000)
          )
        ),
        tap(message => this.logger.debug('received message:' + message)),
        debounceTime(2000),
        switchMap(() => {
          this.refreshInProcess = true;
          this.logger.debug("debounced scoreboard poll");
          return this.readScoreboards();
        }),
      )

    this._socketSubscription = pipedMessages
      .subscribe(responses => {
          this.leagueService.leagueScoreboard = responses.leagueScoreboard;
          this.leagueService.playerScoreboard = responses.playerScoreboard;
          this.leagueService.weekScoreboard = responses.weekScoreboard;
          this.refreshInProcess = false;
        });
  }

  ngOnDestroy()
  {
    if ( this._socketSubscription != null )
      this._socketSubscription.unsubscribe();
  }

  logout ()
  {
    this.userService.logout();
    this.router.navigate(['/'], { skipLocationChange: true });
  }

  changeWeek(newWeek: number)
  {
    this.statusService.weekNumberFilter = newWeek;
    this.reloadScoreboards();
  }

  changePlayer(newPlayerTag: string)
  {
    this.statusService.playerTagFilter = newPlayerTag;
    this.reloadScoreboards();
  }

  changeLeague(league: string)
  {
    this.statusService.leagueCode = league;
    this.refreshInProcess = true;

    this.leagueService.playerScoreboard = null;
    this.leagueService.weekScoreboard = null;
    this.leagueService.leagueScoreboard = null;

    // TODO: move all this to a central location? league service?
    this.userService.setupUser(this.statusService.userName).subscribe(response => 
      {
        this.leagueService.loadPlayers(this.statusService.seasonCode, this.statusService.leagueCode).subscribe(response => 
          {     
              this.leagueService.loadWeeks(this.statusService.seasonCode, this.statusService.leagueCode).subscribe(response => 
                { 
                  this.leagueService.loadPlayerScoreboard(
                    this.statusService.seasonCode, 
                    this.statusService.leagueCode, 
                    this.statusService.weekNumberFilter,
                    this.statusService.playerTagFilter);

                  this.leagueService.loadWeekScoreboard(
                    this.statusService.seasonCode, 
                    this.statusService.leagueCode, 
                    this.statusService.weekNumberFilter
                    );

                  this.leagueService.loadLeagueScoreboard(
                    this.statusService.seasonCode, 
                    this.statusService.leagueCode
                    );

                  // user fully setup go to player view
                  this.statusService.userLoggedInAndInitialized = true;
                  this.refreshInProcess = false;  
                },
                errors => { this.logger.error(errors); }
              );
          },
          errors => { this.logger.error(errors); }
        );
      },
      errors => { this.logger.error(errors); }
    );  
  }

  readScoreboards(): Observable<Scoreboards>
  {

    if ( this.statusService.userLoggedInAndInitialized ) 
    {
      // TODO: move all this to a central location? league service?
      return forkJoin(
        this.leagueService.readLeagueScoreboard(
          this.statusService.seasonCode, 
          this.statusService.leagueCode
        ),
        this.leagueService.readPlayerScoreboard(
          this.statusService.seasonCode, 
          this.statusService.leagueCode,
          this.statusService.weekNumberFilter,
          this.statusService.playerTagFilter
        ),
        this.leagueService.readWeekScoreboard(
          this.statusService.seasonCode, 
          this.statusService.leagueCode, 
          this.statusService.weekNumberFilter
        )
      ).pipe(
        map(([leagueScoreboard, playerScoreboard, weekScoreboard]) => {
          // forkJoin returns an array of values, here we map those values to an object
          return { leagueScoreboard, playerScoreboard, weekScoreboard };
        })
      );
    }
    else
    {
      return of(new Scoreboards());
    }
  }

  reloadScoreboards()
  {
    this.refreshInProcess = true;

    this.readScoreboards().subscribe( responses => {
      this.leagueService.leagueScoreboard = responses.leagueScoreboard;
      this.leagueService.playerScoreboard = responses.playerScoreboard;
      this.leagueService.weekScoreboard = responses.weekScoreboard;
      this.refreshInProcess = false;
    })

  }
}
