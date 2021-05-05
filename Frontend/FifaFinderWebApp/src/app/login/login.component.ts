import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { SharedService } from 'src/app/shared.service';
import { AuthService } from 'src/app/auth/auth.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  registerForm = new FormGroup({
    email: new FormControl(''),
    username: new FormControl(''),
    password: new FormControl('')
  });

  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  });

  public loginDisplay: boolean = false;

  constructor(private service: AuthService) { }

  ngOnInit(): void {

  }

  onRegister() {
    var val = { ID: 0, Username: this.registerForm.value.username, Password: this.registerForm.value.password, Email: this.registerForm.value.email, PictureURL: "" };
    console.log(val);
    this.service.registerUser(val).subscribe(response => {
      alert(response.toString());
    });

  }

  onLogin() {
    var val = { ID: 0, Username: this.loginForm.value.username, Password: this.loginForm.value.password, Email: "", PictureURL: "" };
    console.log(val);
    this.service.loginUser(val).subscribe(response => {
      alert(response.toString());

    });

  }

}
