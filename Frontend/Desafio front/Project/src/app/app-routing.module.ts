import { HomeComponent } from './home/home.component';
import { PersonComponent } from './person/person.component';

import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

const routes: Routes = [
  { path: 'person', component: PersonComponent },
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo:'home', pathMatch: 'full' }]

@NgModule({
  imports: [[RouterModule.forRoot(routes),
    CommonModule]
]})
export class AppRoutingModule { }

