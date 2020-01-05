import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BankModel } from '../Model/BankModel';
import { PaymentWeb } from '../Services/payment.service';
import { AlertService } from '../Services/alert.service';
import { first } from 'rxjs/operators';
import { paymentStatus } from '../Model/PaymentStatus';
import { RechargePlans } from '../Model/RechargePlan';

@Component({
  selector: 'app-netbanking',
  templateUrl: './netbanking.component.html',
  styleUrls: ['./netbanking.component.css']
})
export class NetbankingComponent implements OnInit {
  @Input() SelectedRechargePlan: RechargePlans;
  bankPaymentForm: FormGroup;
  submitted: boolean;
  loading = false;
  paymentStatus: paymentStatus;
  constructor(private formBuilder: FormBuilder, private PaymentWeb: PaymentWeb, private alertService: AlertService) { }

  ngOnInit() {

    this.bankPaymentForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      amount: ['', [Validators.required]],
    });
       
}
  get f() { return this.bankPaymentForm.controls; };

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.bankPaymentForm.invalid) {
      return;
    }
    this.loading = true;
    var bankModel = new BankModel();
    bankModel.userName = this.bankPaymentForm.controls.username.value;
    bankModel.password = this.bankPaymentForm.controls.password.value;
    bankModel.amount = this.bankPaymentForm.controls.amount.value;
    this.PaymentWeb.MakeBankPayment(bankModel)
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
