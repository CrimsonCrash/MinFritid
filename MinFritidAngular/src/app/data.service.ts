import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ibruger } from './data/Ibruger';
import { Iaktivitet } from './data/Iaktivitet';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class DataService {
  [x: string]: any;

  constructor(private http: HttpClient) { }

  getBrugers(): Observable<Ibruger[]>{
    return this.http.get<Ibruger[]>('http://localhost:5001/api/bruger/')

  }

  getBruger(brugerId) {
    return this.http.get('http://localhost:5001/api/bruger/'+ brugerId)
  }

  getAktivitet(): Observable<Iaktivitet[]>{
    return this.http.get<Iaktivitet[]>('http://localhost:5001/api/aktivitet/') 
  }

}
