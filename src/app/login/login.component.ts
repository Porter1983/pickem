import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../sub-system/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router, private userService: UserService) { }

  inputsInvalid: boolean;
  loginErrors: string[] = [];

  ngOnInit() {
  }

  tryLogin(username: string, password: string) {

    this.inputsInvalid = false;

    this.userService.login(username, password)
      .subscribe(
        result => {
          // result will be true if succesful. If false is 401, bad pwd. All other issues are thrown.
          this.inputsInvalid = false;
          this.router.navigate(['/player'], { skipLocationChange: true });
        },
        errors => {
          this.inputsInvalid = true;
          this.loginErrors = errors;
        }
      );

  }
}
