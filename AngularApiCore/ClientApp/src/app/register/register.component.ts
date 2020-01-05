import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../Services/user.service'
import { from } from 'rxjs';
import { Router, NavigationStart } from '@angular/router';
import { AlertService } from '../Services/alert.service';
import { first } from 'rxjs/operators';
import { UserDetails } from '../Model/UserDetails';
import { UserResult } from '../Model/UserResult';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  submitted: boolean;
  loading = false;
  userresult: UserResult;
  userStatus: boolean;
 
  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
    private alertService: AlertService) {

  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      email: ['', [Validators.required, Validators.email]],


    });
  }
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }
    this.loading = true;
    var userDetails = new UserDetails();
     userDetails.username = this.registerForm.controls.username.value;
    userDetails.password = this.registerForm.controls.password.value;
    userDetails.email = this.registerForm.controls.email.value;
    this.userService.Register(userDetails)
      .pipe(first())
      .subscribe(
        data => {
          console.log(data);
        
          this.userresult = data;
          console.log(this.userresult);
          this.userStatus = this.userresult.status

          console.log(this.userresult.status);
          if (this.userresult.status) {
            this.alertService.success('Registration successful', true);
            this.router.navigate(['/login']);
          } else {
            this.loading = false;
            this.submitted = false;
          }
        },
        error => {
          console.log(error);
          this.alertService.error(error);
          this.loading = false;
        });
  }
}
