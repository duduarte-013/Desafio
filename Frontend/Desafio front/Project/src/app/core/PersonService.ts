import { Person } from './../model/Person';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';



@Injectable({
  providedIn: 'root'
})
export class PersonService {

  url = "http://localhost:42773/persons";
  
  constructor(private http: HttpClient) { }

  add(person: Person) {
    return this.http.post(this.url, person);
  }

  

  updatePerson(id: number, person: Person) {
    return this.http.put(`${this.url}/${id}`, person);
  }

  deletePerson(id: number) {
    return this.http.delete(`${this.url}/${id}`);
  }

  getById(id: number) {
    return this.http.get(`${this.url}/${id}`)
  }
  
  getAll() {
    return this.http.get(this.url)
  }
  

}
