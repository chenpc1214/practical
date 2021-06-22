import { Component, OnInit } from '@angular/core';
import { ShareService } from '../../services/share.service';

@Component({
  selector: 'app-show-emp',
  templateUrl: './show-emp.component.html',
  styleUrls: ['./show-emp.component.css'],
})
export class ShowEmpComponent implements OnInit {
  constructor(private service: ShareService) {}

  EmployeeList: any = [];
  Title: string = '';
  Active: boolean = false;
  emp: any;

  ngOnInit(): void {
    this.Refresh();
  }

  Refresh() {
    this.service.GetEmpList().subscribe((data) => (this.EmployeeList = data));
  }

  AddClick() {
    this.emp = {
      ID: 0,
      NAME: "",
      DEP: "",
      HRD: "",
      PHOTO_FILE: "anonymous.png"
    };
    this.Title = '新增員工';
    this.Active = true;
  }

  CloseClick() {
    this.Active = false;
    this.Refresh();
  }

  EditClick(item: any) {
    this.emp = item;
    this.Title = '編輯員工';
    this.Active = true;
  }

  DeleteClick(item: any) {
    if (confirm('確定要刪除嗎?')) {
      this.service.DeleteEmp(item.ID).subscribe((data) => {
        alert(data.toString());
        this.Refresh();
      });
    }
  }
}
