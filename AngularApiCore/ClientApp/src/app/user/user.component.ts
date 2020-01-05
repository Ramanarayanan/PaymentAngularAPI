import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../Services/authentication.service';
import { User } from '../Model/User';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  currentUser: User;

  constructor(
    
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }


  ngOnInit() {
  }

}
