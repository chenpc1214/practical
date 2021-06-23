import { Component, OnInit } from '@angular/core';
import{ShareService}from'../../services/share.service';

@Component({
  selector: 'app-show-dep',
  templateUrl: './show-dep.component.html',
  styleUrls: ['./show-dep.component.css'],
})
export class ShowDepComponent implements OnInit {
  constructor(private service: ShareService) {}

  DepartmentList: any = [];
  Title: string = '';
  Active: boolean = false;
  dep: any;

  Department_ID_Filter: string = ''; //用來接輸入框來的文字
  Department_Name_Filter: string = ''; //用來接輸入框來的文字
  Department_List_No_Filter: any = []; //因為JS是傳址，要多做一項陣列，做為搜索用

  ngOnInit(): void {
    this.Refresh();
  }

  Refresh() {
    this.service.GetDepList().subscribe((data) => {
      this.DepartmentList = data;
      this.Department_List_No_Filter = data;
    });
  }

  AddClick() {
    this.dep = {
      DEP_ID: 0,
      DEP_NAME: '',
    };
    this.Title = '新增部門';
    this.Active = true;
  }

  CloseClick() {
    this.Active = false;
    this.Refresh();
  }

  EditClick(item: any) {
    this.dep = item;
    this.Title = '編輯部門';
    this.Active = true;
  }

  DeleteClick(item: any) {
    if (confirm('確定要刪除嗎?')) {
      this.service.DeleteDep(item.DEP_ID).subscribe((data) => {
        alert(data.toString());
        this.Refresh();
      });
    }
  }

  MyFilter() {
    var Department_ID_Filter = this.Department_ID_Filter; //會從輸入框來的文字
    var Department_Name_Filter = this.Department_Name_Filter; //會從輸入框來的文字

    this.DepartmentList = this.Department_List_No_Filter.filter(function (element: any) {
      return (
        element.DEP_ID.toString()
          .toLowerCase()
          .includes(Department_ID_Filter.toString().trim().toLowerCase()) &&
        element.DEP_NAME.toString()
          .toLowerCase()
          .includes(Department_Name_Filter.toString().trim().toLowerCase())
      );
    });
  }

  MySort(element:any ,asc:boolean ){

    this.DepartmentList=this.Department_List_No_Filter.sort(function(a:any,b:any){

      if(asc){

        return a[element]>b[element] ? 1 : (  (a[element]<b[element]) ? -1 : 0 ) ;
      }
      else{
        return b[element] > a[element] ? 1 :(  (b[element] < a[element]) ? -1 : 0 );
      }

    })

  }



}
