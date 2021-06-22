import { Component, OnInit,Input } from '@angular/core';
import { ShareService } from '../../services/share.service';

@Component({
  selector: 'app-add-edit-emp',
  templateUrl: './add-edit-emp.component.html',
  styleUrls: ['./add-edit-emp.component.css'],
})
export class AddEditEmpComponent implements OnInit {
  constructor(private service: ShareService) {}

  @Input() emp: any;

  ID: string = '';
  NAME: string = '';
  DEP: string = '';
  HRD: string = '';
  PHOTO_FILE: string = '';
  PHOTO_PATH: string = '';

  DepartmentList: any = [];




  ngOnInit(): void {
    this.Load_Department_List();
  }

  Load_Department_List() {
    this.service.GetTotalDepName().subscribe((data) => {
      this.DepartmentList = data;

      this.ID = this.emp.ID;
      this.NAME = this.emp.NAME;
      this.DEP = this.emp.DEP;
      this.HRD = this.emp.HRD;
      this.PHOTO_FILE = this.emp.PHOTO_FILE;
      this.PHOTO_PATH = this.service.PhotoUrl + this.PHOTO_FILE;
    });
  }

  AddNew() {
    var value = {
      ID: this.ID,
      NAME: this.NAME,
      DEP: this.DEP,
      HRD: this.HRD,
      PHOTO_FILE: this.PHOTO_FILE,
    };

    this.service.AddEmp(value).subscribe((res) => {
      alert(res.toString());
    });
  }

  UpdateEmployee() {
    var value = {
      ID: this.ID,
      NAME: this.NAME,
      DEP: this.DEP,
      HRD: this.HRD,
      PHOTO_FILE: this.PHOTO_FILE,
    };

    this.service.UpdateEmp(value).subscribe((res) => {
      alert(res.toString());
    });
  }

  upLoadFile(event: any) {
    var file = event.target.files[0];
    const formData: FormData = new FormData();
    formData.append('UploadFile', file, file.name);

    this.service.UploadPhoto(formData).subscribe((data) => {
      this.PHOTO_FILE = data.toString();
      this.PHOTO_PATH = this.service.PhotoUrl + this.PHOTO_FILE;
    });
  }


  test() {
    console.log("檔名：",this.PHOTO_FILE)
    console.log("路徑：",this.PHOTO_PATH);
    console.log("所有部門",this.DepartmentList)
  }
}
