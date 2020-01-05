import { Component, OnInit, Input } from '@angular/core';
import { RechargePlans } from '../Model/RechargePlan';
import { PaymentWeb } from '../Services/payment.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  @Input() PreRechargePlans: RechargePlans;
  PaymentMethodlist: any[];
  enableNetBanking: boolean = false;
  enableCardPayment: boolean = false;
  enablePayments: boolean = false;
  readioSelected: any;
  constructor(private PaymentWeb: PaymentWeb) { }

  ngOnInit() {
    this.enablePayments = false;
    this.PaymentMethodlist = [
      {
        method: 'NetBanking',

      },
      {
        method: 'Debit/Credit Card',

      },
    ]
  }


  onSelectionChange(method: string)
  {
  
    this.enablePayments = true;
    if (method == "NetBanking") {

      this.enableNetBanking = true;
    }
   
    if (method == 'Debit/Credit Card') {
      this.enableNetBanking = false;
      
    }
   
   
  }

  onCancel() {
    this.enablePayments = false;
    this.enableNetBanking = false;
    this.enableCardPayment = false;
  }
  

}
