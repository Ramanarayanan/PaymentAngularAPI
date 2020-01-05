import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { PaymentWeb } from '../Services/payment.service';
import { first } from 'rxjs/operators';
import { CardPayment } from '../Model/CardPayment';
import { AlertService } from '../Services/alert.service';
import { pipe } from 'rxjs';
import { RechargePlans } from '../Model/RechargePlan';

@Component({
  selector: 'app-cardpayment',
  templateUrl: './cardpayment.component.html',
  styleUrls: ['./cardpayment.component.css']
})
export class CardpaymentComponent implements OnInit {
  @Input() SelectedRechargePlan: RechargePlans;
  cardPaymentForm: FormGroup;
  submitted: boolean;
  loading = false;
  paymentStatus: any;
  payAmount: number;

  constructor(private formBuilder: FormBuilder,private PaymentWeb: PaymentWeb,
    private alertService: AlertService) { }

  ngOnInit() {

    this.cardPaymentForm = this.formBuilder.group({
      cardnumber: ['', Validators.required],
      cvvnumber: ['', [Validators.required, Validators.minLength(3)]],
      expiryDate: ['', [Validators.required]],
      cardHolderName: ['', [Validators.required]],
      amount: [this.SelectedRechargePlan.Mrp, [Validators.required]],


    });

    
  }

  get f() { return this.cardPaymentForm.controls; }


  onSubmit() {
    this.submitted = true;
    this.loading = true;
    // stop here if form is invalid
    if (this.cardPaymentForm.invalid) {
      return;
    }

    let cardPayment = new CardPayment();
    cardPayment.cardNumber = this.cardPaymentForm.controls.cardnumber.value;
    cardPayment.cvvNumber = this.cardPaymentForm.controls.cvvnumber.value;
    cardPayment.expiryDate = this.cardPaymentForm.controls.expiryDate.value;
    cardPayment.Amount = this.cardPaymentForm.controls.amount.value;
    cardPayment.cardHolderName = this.cardPaymentForm.controls.cardHolderName.value;
    this.PaymentWeb.MakeCardPayment(cardPayment)
      .pipe(first())
      .subscribe(
        data => {
          console.log(data);

          this.paymentStatus = data;
          this.loading = false;
         
        },
        error => {
          console.log(error);
          this.alertService.error(error);
          this.loading = false;
        });
  }
}
