import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-postpaid',
  templateUrl: './postpaid.component.html',
  styleUrls: ['./postpaid.component.css']
})
export class PostpaidComponent implements OnInit {
  PostOperaterList: any[];
  enablePay: boolean;
  cosumerNo: string
  constructor() { }

  ngOnInit() {

    this.PostOperaterList = [{
      "Id": "Post paid Mobile",
      "Name": "Post paid Mobile"
    },
    {
      "Id": "Electricity Bill",
      "Name": "Electricity Bill"
    },
    {
      "Id": "Braodband",
      "Name": "Braodband"
    }
    ]


  }


  selectName() {
    if (this.cosumerNo != "") {
      this.enablePay = true;
    }
   

  }
}
