import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDetails } from '../Model/UserDetails';
import { Observable, of } from 'rxjs';
import { CardPayment } from '../Model/CardPayment';
import { map } from 'rxjs/operators';
import { BankModel } from '../Model/BankModel';
import { paymentStatus } from '../Model/PaymentStatus';
@Injectable({
  providedIn: 'root'
})
export class PaymentWeb {
  private baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }



  MakeCardPayment(cardPayment: CardPayment): Observable<paymentStatus>{
    return this.http.post<paymentStatus>(this.baseUrl + '/api/Payment/MakeCardPayment', cardPayment);
  }



  MakeBankPayment(bankModel: BankModel): Observable<paymentStatus> {
    return this.http.post<paymentStatus>(this.baseUrl + '/api/Payment/MakeBankPayment', bankModel);
  }
}
