import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import{FormsModule , ReactiveFormsModule } from '@angular/forms'

import { ShareService } from './services/share.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from '../app/root/app.component';
import { DepComponentComponent } from '../app/dep-component/dep-component.component';
import { ShowDepComponent } from './dep-component/show-dep/show-dep.component';
import { AddEditDepComponent } from './dep-component/add-edit-dep/add-edit-dep.component';
import { EmpComponentComponent } from './emp-component/emp-component.component';
import { ShowEmpComponent } from './emp-component/show-emp/show-emp.component';
import { AddEditEmpComponent } from './emp-component/add-edit-emp/add-edit-emp.component';




@NgModule({
  declarations: [
    AppComponent,
    DepComponentComponent,
    ShowDepComponent,
    AddEditDepComponent,
    EmpComponentComponent,
    ShowEmpComponent,
    AddEditEmpComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [ShareService],
  bootstrap: [AppComponent],
})
export class AppModule {}
