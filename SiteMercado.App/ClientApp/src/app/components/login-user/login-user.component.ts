import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.css']
})
export class LoginUserComponent implements OnInit {
  form: FormGroup;

  constructor(private auth: AuthService, private fb: FormBuilder, private router: Router) {  }

  ngOnInit() {
    console.log('checked', this.auth.checkLogged);
    //if (this.auth.checkLogged) {
    //  this.router.navigate(['/']);
    //}

    this.form = this.fb.group({
      Username: [null, Validators.required],
      Password: [null, Validators.required]
    })
  }

  loginCustomer() {
    this.auth.loginCustomer(this.form.value);
  }
}
