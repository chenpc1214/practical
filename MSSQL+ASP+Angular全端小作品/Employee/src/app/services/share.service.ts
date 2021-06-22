import { Injectable } from '@angular/core';
import{HttpClient} from'@angular/common/http';
import{Observable, observable} from 'rxjs'

@Injectable({
  providedIn: 'root',
})
export class ShareService {
  readonly APIUrl = 'https://localhost:44393/api';
  readonly PhotoUrl = 'https://localhost:44393/Photos/';

  constructor(private http: HttpClient) {}

  //DEP負責的

  GetDepList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/DEP');
  }

  AddDep(val: any) {
    return this.http.post(this.APIUrl + '/DEP', val);
  }

  UpdateDep(val: any) {
    return this.http.put(this.APIUrl + '/DEP', val);
  }

  DeleteDep(val: any) {
    return this.http.delete(this.APIUrl + '/DEP/' + val);
  }

  //EMP負責的

  GetEmpList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/EMP');
  }

  AddEmp(val: any) {
    return this.http.post(this.APIUrl + '/EMP', val);
  }

  UpdateEmp(val: any) {
    return this.http.put(this.APIUrl + '/EMP', val);
  }

  DeleteEmp(val: any) {
    return this.http.delete(this.APIUrl + '/EMP/' + val);
  }


  UploadPhoto(val:any): Observable<any[]> {
    return this.http.post<any[]>(this.APIUrl + '/EMP/SaveFile',val);
  }

  GetTotalDepName(): Observable<any[]> {
    return this.http.get<any[]>(this.APIUrl + '/EMP/GetTotalDepName');
  }

}
