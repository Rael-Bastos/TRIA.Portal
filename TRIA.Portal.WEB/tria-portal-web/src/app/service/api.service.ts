import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

constructor(private http: HttpClient) { }

getApi(url: string):Observable<any>{

    return this.http.get<any>(environment.api.concat('api/',url))
    .pipe(catchError(this.handleError));

}
postApi(url: string, parametrs: any):Observable<any>{
  return this.http.post<any>(environment.api.concat('api/',url), parametrs)
  .pipe(catchError(this.handleError));
}
putApi(url: string, parametrs: any):Observable<any>{
  return this.http.put<any>(environment.api.concat('api/',url), parametrs)
  .pipe(catchError(this.handleError));
}
deleteApi(url: string):Observable<any>{
  return this.http.delete<any>(environment.api.concat('api/',url))
  .pipe(catchError(this.handleError));
}

handleError(error: any){
return throwError(error.message || "Server Erro");
}

}
