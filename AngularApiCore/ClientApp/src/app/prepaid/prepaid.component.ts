import { Component, OnInit } from '@angular/core';
import { OperaterService } from '../Services/operater.service'
import { AlertService } from '../Services/alert.service';
import { RechargePlans } from '../Model/RechargePlan';
@Component({
  selector: 'app-prepaid',
  templateUrl: './prepaid.component.html',
  styleUrls: ['./prepaid.component.css']
})
export class PrepaidComponent implements OnInit {
  OperaterList: any[];
  data: any;
  operater: string;
  operaterName: string;
  rechargeList: RechargePlans[];
  loading: boolean;
  enablePay: boolean = false;
  constructor(private operatorService: OperaterService,
    private alertService: AlertService) {
    this.OperaterList = [{
      "Id": "Airtel",
      "Name": "Airtel"
    },
      {
        "Id": "BSNL",
        "Name": "BSNL"
      },
      {
        "Id": "Idea",
        "Name": "Idea"
      }
    ]
    

  }

  ngOnInit() {
  }
 
  selectName() {
    alert(this.operater);
    this.enablePay = true;
    this.operaterName = this.operater;

   
  }

    


}
