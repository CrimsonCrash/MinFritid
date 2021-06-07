import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ibruger } from './data/Ibruger';
import { Iaktivitet } from './data/Iaktivitet';
import { IloginRequest } from './data/IloginRequest';
import { IloggedIn } from './data/IloggedIn';


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
  header: any;
  constructor(private http: HttpClient) { 
    // const headerSettings: {[name: string]: string | string[];} = {};
    // this.header = new HttpHeaders(headerSettings);
  }

  getBrugers(): Observable<Ibruger[]>{
    return this.http.get<Ibruger[]>('http://localhost:5001/api/bruger/')

  }

  getBruger(brugerId) {
    return this.http.get('http://localhost:5001/api/bruger/'+ brugerId)
  }

  postBrugers(bruger: Ibruger): Observable<Ibruger>{
    //const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/text'}) };
    return this.http.post<Ibruger>('http://localhost:5001/api/bruger', bruger, httpOptions)
  }

  public login(loginRequest: IloginRequest): Observable<IloginRequest> {
    return this.http.post<IloginRequest>('http://localhost:5001/api/account/login', loginRequest, httpOptions);
  }

  public getLogin(): Observable<IloggedIn>{
    return this.http.get<IloggedIn>('http://localhost:5001/api/account/loggedIn');
  }

  public logOut(){
    return this.http.get('http://localhost:5001/api/account/logout')
  }

  // postBrugers(bruger: Ibruger): Observable<Ibruger>{
  //   return this.http.post<Ibruger>('http://localhost:5001/api/bruger/', bruger, httpOptions)
  // }

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

  getAktivitet(aktivitetId): Observable<Iaktivitet>{
    return this.http.get<Iaktivitet>('http://localhost:5001/api/aktivitet/' + aktivitetId) 
  }

  findAktivitet(titel : any): Observable<Iaktivitet>{
    return this.http.get<Iaktivitet>('http://localhost:5001/api/aktivitet/' + titel)
  }

  postAktivitet(aktivitet : Iaktivitet): Observable<Iaktivitet>{
    return this.http.post<Iaktivitet>('http://localhost:5001/api/aktivitet/', aktivitet, httpOptions)
  }

  putAktivitet(aktivitet, id): Observable<Iaktivitet>{
    return this.http.put<Iaktivitet>('http://localhost:5001/api/aktivitet/' + id, JSON.stringify(aktivitet), httpOptions)
  }

  delAktivitet(aktivitetId) {
    return this.http.delete('http://localhost:5001/api/aktivitet/'+ aktivitetId)
  }

  deaktivateAktivitet(brugerId){
    return this.http.get('http://localhost:5001/api/aktivitet/deaktiv/' + brugerId)
  }

}
