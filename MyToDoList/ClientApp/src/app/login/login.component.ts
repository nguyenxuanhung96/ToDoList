import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from '../service/user.service'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public userName: string;
  public pass: string;

  returnUrl: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onLogin() {
    if (this.userName && this.pass) {
      this.userService.getUser(this.userName, this.pass)
        .subscribe(user => {
          if (user) {
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.router.navigate([this.returnUrl]);
          }
          else {
            alert("User or pass is invalid!");
          }
        });
    }
  }


}
