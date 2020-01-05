import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
   
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

//constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
//  const auth = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ijk4YzhmNzgxLWYxN2QtNGEzNC1iNTY4LWM1Njk3ZWM1MjcwNSIsIm5iZiI6MTU3NzQ2OTQwNiwiZXhwIjoxNTc4MDc0MjA2LCJpYXQiOjE1Nzc0Njk0MDZ9.oJjYo6xAT_G96x4zYCoLAlfrFKYygrTskYa7Lq-CPj0'
//  const headerser = new HttpHeaders({
//    'Content-Type': 'application/json',
//    'Authorization': `Bearer ${auth}`
//  })
//  http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts', { headers: headerser }).subscribe(result => {
//    this.forecasts = result;
//  }, error => console.error(error));
//}
