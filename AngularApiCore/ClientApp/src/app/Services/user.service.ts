import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDetails } from '../Model/UserDetails';
import { Observable, of } from 'rxjs';
import { UserResult } from '../Model/UserResult'
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl: string;
  constructor(private http: HttpClient,@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }


  Register(user: UserDetails): Observable<UserResult> {
    return this.http.post<UserResult>(this.baseUrl + '/api/users/RegisterUser', user);
     
      
  };


  private handleError<T>(result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  };
}
