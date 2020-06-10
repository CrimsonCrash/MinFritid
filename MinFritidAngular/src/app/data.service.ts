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

  postBrugers(bruger: Ibruger): Observable<Ibruger>{
    return this.http.post<Ibruger>('http://localhost:5001/api/bruger/', bruger, httpOptions)
  }

  delBruger(brugerId) {
    return this.http.delete('http://localhost:5001/api/bruger/'+ brugerId)
  }

  putBrugers(bruger: Ibruger, brugerId): Observable<Ibruger>{
    return this.http.put<Ibruger>('http://localhost:5001/api/bruger/' + brugerId, bruger, httpOptions)
  }

  aktiverBruger(brugerId) {
    return this.http.get('http://localhost:5001/api/bruger/aktiv/'+ brugerId)
  }

  deaktiverBruger(brugerId) {
    return this.http.get('http://localhost:5001/api/bruger/deaktiv/'+ brugerId)
  }

  getAktiviteter(): Observable<Iaktivitet[]>{
    return this.http.get<Iaktivitet[]>('http://localhost:5001/api/aktivitet/') 
  }

  getAktivitet(aktivitetId){
    return this.http.get('http://localhost:5001/api/aktivitet/' + aktivitetId) 
  }

  postAktivitet(aktivitet : Iaktivitet): Observable<Iaktivitet>{
    return this.http.post<Iaktivitet>('http://localhost:5001/api/aktivitet/', aktivitet, httpOptions)
  }

  putAktivitet(aktivitet : Iaktivitet, brugerId): Observable<Iaktivitet>{
    return this.http.put<Iaktivitet>('http://localhost:5001/api/aktivitet/' + brugerId, aktivitet, httpOptions)
  }

  delAktivitet(aktivitetId) {
    return this.http.delete('http://localhost:5001/api/aktivitet/'+ aktivitetId)
  }

  deaktivateAktivitet(brugerId){
    return this.http.get('http://localhost:5001/api/aktivitet/deaktiv/' + brugerId)
  }

}
