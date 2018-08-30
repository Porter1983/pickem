﻿using Marten;
using PickEmServer.Api.Models;
using PickEmServer.App;
using PickEmServer.Data.Models;
using System;
using System.Collections.Generic;

namespace PickEmServer.Heart
{
    internal class GameChanger
    {
        private GameData _game;
        private IDocumentSession _dbSession;

        internal GameChanger(GameData game, IDocumentSession dbSession)
        {
            _game = game;
            _dbSession = dbSession;
        }

        internal GameChanges ApplyChanges(GameUpdate gameUpdates)
        {
            GameChanges gameChanges = new GameChanges();

            _game.LastUpdated = gameUpdates.LastUpdated;
            _game.CurrentPeriod = gameUpdates.CurrentPeriod;
            _game.TimeClock = gameUpdates.TimeClock;
            _game.GameStart = gameUpdates.GameStart;
            if ( this.UpdateAwayTeamScore(gameUpdates.AwayTeamScore) )
            {
                gameChanges.ScoreChanged = true;
            }

            if ( this.UpdateHomeTeamScore(gameUpdates.HomeTeamScore) )
            {
                gameChanges.ScoreChanged = true;
            }

            gameChanges.GameStateChanged = this.UpdateGameState(gameUpdates.GameState);

            return gameChanges;
        }

        internal void ApplySpread(SpreadUpdate spreadUpdates)
        {
            if ( _game.GameState != GameStates.SpreadNotSet )
            {
                throw new InvalidOperationException($"Cannot update game id: {_game.GameId} spread because the game state is: {_game.GameState}");
            }

            _game.Spread.PointSpread = spreadUpdates.PointSpread;
            _game.Spread.SpreadDirection = spreadUpdates.SpreadDirection;

            this.SynchScoresAfterSpread();
        }

        internal void LockSpread()
        {
            if (_game.GameState != GameStates.SpreadNotSet)
            {
                throw new InvalidOperationException($"Cannot lock game id: {_game.GameId} spread because the game state is: {_game.GameState}");
            }

            _game.GameState = GameStates.SpreadLocked;
        }

        private bool UpdateGameState(GameStates newGameState)
        {
            if ( _game.GameState != newGameState )
            {
                _game.GameState = newGameState;

                if ( newGameState == GameStates.Final )
                {
                    _game.AwayTeam.Winner = (_game.AwayTeam.Score > _game.HomeTeam.Score);
                    _game.HomeTeam.Winner = (_game.AwayTeam.Score < _game.HomeTeam.Score);
                }
                
                // game state changed
                return true;
            }

            return false;
        }

        private bool UpdateAwayTeamScore(int newScore)
        {
            if ( _game.AwayTeam.Score != newScore )
            {
                _game.AwayTeam.Score = newScore;
                this.SynchScoresAfterSpread();

                // score changed
                return true;
            }

            return false;
        }

        private bool UpdateHomeTeamScore(int newScore)
        {
            if (_game.HomeTeam.Score != newScore)
            {
                _game.HomeTeam.Score = newScore;
                this.SynchScoresAfterSpread();

                // score changed
                return true;
            }

            return false;
        }

        private void SynchScoresAfterSpread()
        {
            //  - game: update score after spread
            switch (_game.Spread.SpreadDirection)
            {
                case SpreadDirections.None:
                    _game.AwayTeam.ScoreAfterSpread = _game.AwayTeam.Score;
                    _game.HomeTeam.ScoreAfterSpread = _game.HomeTeam.Score;
                    break;

                case SpreadDirections.ToAway:
                    _game.AwayTeam.ScoreAfterSpread = _game.AwayTeam.Score + _game.Spread.PointSpread;
                    _game.HomeTeam.ScoreAfterSpread = _game.HomeTeam.Score;
                    break;

                case SpreadDirections.ToHome:
                    _game.AwayTeam.ScoreAfterSpread = _game.AwayTeam.Score;
                    _game.HomeTeam.ScoreAfterSpread = _game.HomeTeam.Score + _game.Spread.PointSpread;
                    break;
            }
        }
    }
}
