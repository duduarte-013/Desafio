import { Person } from './../model/Person';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';



@Injectable({
  providedIn: 'root'
})
export class CityService {

  url = "http://localhost:42773/cities";
  
  constructor(private http: HttpClient) { }


  getAll() {
    return this.http.get(this.url)
  }

  

}
