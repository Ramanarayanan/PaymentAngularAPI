import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDetails } from '../Model/UserDetails';
import { Observable, of } from 'rxjs';
import { RechargePlans } from '../Model/RechargePlan';

@Injectable({
  providedIn: 'root'
})
export class OperaterService {
  private baseUrl: string;

  public forecasts: RechargePlans[]=[];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl;
  }





  GetOperaterDetails(operator: string): Observable<RechargePlans[]> {
    return this.http.get<RechargePlans[]>(this.baseUrl + '/api/Operator/GetOperatorRechargePlans?operater=' + operator);

           
  };


  private handleError<T>(result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  };
}
