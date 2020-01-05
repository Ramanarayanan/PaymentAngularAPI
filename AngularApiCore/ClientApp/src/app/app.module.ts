import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
//import { fakeBackendProvider } from './helpers/fake-backend';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';
import { AuthGuard } from './gaurds/AuthGuard';
import { RegisterComponent } from './register/register.component';
import { PostpaidComponent } from './postpaid/postpaid.component';
import { PrepaidComponent } from './prepaid/prepaid.component';
import { PaymentComponent } from './payment/payment.component';
import { AlertComponent } from './directive/alert/alert.component';
import { OperateterTableComponent } from './operateter-table/operateter-table.component';
import { CardpaymentComponent } from './cardpayment/cardpayment.component';
import { NetbankingComponent } from './netbanking/netbanking.component';
import { NonavComponent } from './nonav/nonav.component';
import { UserComponent } from './user/user.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    RegisterComponent,
    PostpaidComponent,
    PrepaidComponent,
    PaymentComponent,
    AlertComponent,
    OperateterTableComponent,
    CardpaymentComponent,
    NetbankingComponent,
    NonavComponent,
    UserComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'prepaid', component: PrepaidComponent, canActivate: [AuthGuard] },
      { path: 'postpaid', component: PostpaidComponent, canActivate: [AuthGuard] },
      { path: 'user', component: UserComponent, canActivate: [AuthGuard]},
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    JwtInterceptor
    // provider used to create fake backend
    //fakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
