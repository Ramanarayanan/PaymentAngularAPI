import { Component, OnInit } from '@angular/core';
import { User } from '../Model/User';


@Component({
  selector: 'app-nonav',
  templateUrl: './nonav.component.html',
  styleUrls: ['./nonav.component.css']
})
export class NonavComponent implements OnInit {
  isExpanded = false;

  constructor() { }

  ngOnInit() {
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
