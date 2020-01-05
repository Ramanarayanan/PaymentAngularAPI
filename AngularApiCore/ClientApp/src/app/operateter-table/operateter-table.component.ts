import { Component, OnInit, Input, Inject } from '@angular/core';
import { AlertService } from '../Services/alert.service';
import { OperaterService } from '../Services/operater.service';
import { RechargePlans } from '../Model/RechargePlan';
import { HttpClient, HttpHeaders } from '@angular/common/http';



@Component({
  selector: 'app-operateter-table',
  templateUrl: './operateter-table.component.html',
  styleUrls: ['./operateter-table.component.css']
})
export class OperateterTableComponent implements OnInit {
  @Input() OperaterName: string;
  rechargeList: any[] = [];
  recharge: RechargePlans;
  selectedPlan: any;
  days: string;
  http: HttpClient;
  baseUrl: string;
  PaymentMethodlist: any[];
  enablePayments: boolean = false;
  constructor(private operatorService: OperaterService,
    private alertService: AlertService, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    if (this.OperaterName != "") {
      this.GetRechargeDetails();
    }
  }


  onSelect(recharge: any) {
    this.selectedPlan = recharge;
    alert(this.selectedPlan);
    console.log(this.selectedPlan);
    this.enablePayments = true;
   
  }
  GetRechargeDetails() {
    console.log(this.OperaterName);


    this.http.get<RechargePlans[]>(this.baseUrl + '/api/Operator/GetOperatorRechargePlans?operater=' + this.OperaterName).subscribe(result => {
      this.rechargeList = result;
      console.log(this.rechargeList);
      console.log(this.rechargeList[0]);
    })
     
    //this.operatorService.GetOperaterDetails(this.OperaterName)
      
    // .subscribe(
    //    //data => {
    //    //  console.log(data);

    //    //  for (let i = 0; i < data.length; i++) {


    //    //    //this.recharge = {
           
    //    //    //  Descriptions =data[i].Descriptions,

    //    //    //  }
          
    //    //    //this.recharge.Data = data[i].Data;
    //    //    //this.recharge.Descriptions = data[i].Descriptions;
    //    //    //this.recharge.Id = data[i].Id;
    //    //    //this.recharge.Mrp = data[i].Mrp;
    //    //    //this.recharge.Operater = data[i].Operater;
    //    //    //this.recharge.Roaming = data[i].Roaming;
    //    //    //this.recharge.Sms = data[i].Sms;
    //    //    //this.recharge.ValidateDays = data[i].ValidateDays;

    //    //    this.rechargeList.push(this.recharge);
    //    //  }
    //    //  this.rechargeList = data;

    //    //  console.log(" the recharge list" + this.rechargeList[0].Data);
    //    //},

    //    //(data) => {
    //    //  console.log(data);

    //    //  let rech = new RechargePlans();

    //    //  console.log("the data" + data[0].ValidateDays.toString());
    //    //  rech.ValidateDays = data[0].ValidateDays;
    //    //  this.rechargeList.push(rech);
           
    //    //  console.log(this.rechargeList[0]);

    //    data => {
    //     console.log(data);

    //     for (let value of data) {
    //       //let test = Object.create(value);
    //       console.log(JSON.stringify(value));

    //       this.rechargeList.push(JSON.stringify(value))
    //     }
    //     debugger;
    //     // this.rechargeList = JSON.parse(data);
    //     // this.rechargeList = JSON.parse(this.rechargeList)
    //    // var rechare = new RechargePlans();
        
    //   //  rechare.ValidateDays = data[0].ValidateDays;
    //     console.log(data[0].ValidateDays);
    //     console.log(this.rechargeList[0].ValidateDays);
    //     //console.log(this.rechargeList.push(rechare));
    //    },
    //    error => {
    //      console.log(error);
    //      this.alertService.error(error);
    //    //  this.loading = false;
    //    });
  }
}
