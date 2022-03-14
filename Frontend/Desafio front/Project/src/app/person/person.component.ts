import { Person } from './../model/Person';
import { PersonService } from './../core/PersonService';
import { CityService } from './../core/CityService';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FormsModule } from '@angular/forms'; 
import { ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {
cityList: any ;
personList: any;

  public formPerson: FormGroup = new FormGroup({
    'name': new FormControl(null, [
      Validators.required
    ]),
    'cpf': new FormControl(null, [
      Validators.required
    ]),
    'cityId': new FormControl(null, [
      Validators.required
    ]),
    'age': new FormControl(null, [
      Validators.required
    ])
  })
  constructor(private CityService: CityService,
             private PersonService: PersonService) { }

  ngOnInit() {
    this.getCities()
    this.getAllPersons()
  }

  getCities() {
    this.CityService.getAll().subscribe((data) => {
      this.cityList = data;
     console.log(this.cityList)
      
    });

   
}

add() { 
  let person: Person = new Person(this.formPerson.value.name,
    this.formPerson.value.cpf,this.formPerson.value.cityId, this.formPerson.value.age );
  this.PersonService.add(person).subscribe(
    (success) => {
      console.log("ok")
      this.formPerson.reset();
      this.getAllPersons()
})}


getAllPersons() { 
  this.PersonService.getAll().subscribe((data) => {
    this.personList = data;
   console.log(this.personList)
})
  }


   delete(id: number) { 
     this.PersonService.deletePerson(id).subscribe((data) => {
       var idDeleted = data;
       console.log(idDeleted)
       this.getAllPersons()
       
     })
   }
}
