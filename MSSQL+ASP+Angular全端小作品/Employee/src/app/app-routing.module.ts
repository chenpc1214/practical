import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EmpComponentComponent } from './emp-component/emp-component.component';
import{  DepComponentComponent } from'./dep-component/dep-component.component';

const routes: Routes = [
  { path: 'employee', component: EmpComponentComponent },
  { path: 'department', component: DepComponentComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
