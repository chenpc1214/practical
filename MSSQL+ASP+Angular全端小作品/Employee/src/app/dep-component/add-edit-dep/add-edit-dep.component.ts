import { Component, OnInit,Input } from '@angular/core';
import { ShareService } from '../../services/share.service';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css'],
})
export class AddEditDepComponent implements OnInit {
  @Input() dep: any;
  DEP_ID: string = '';
  DEP_NAME: string = '';

  constructor(private service :ShareService) {}

  ngOnInit(): void {
    this.DEP_ID = this.dep.DEP_ID;
    this.DEP_NAME = this.dep.DEP_NAME;
  }

  AddNew(){
    
    var value = {
      DEP_ID:this.DEP_ID,
      DEP_NAME:this.DEP_NAME
    };

    this.service.AddDep(value).subscribe(res=>{
      alert(res.toString());
    })

  }

  UpdateDep(){

    var value = {
      DEP_ID: this.DEP_ID,
      DEP_NAME: this.DEP_NAME,
    };

    this.service.UpdateDep(value).subscribe((res) => {
      alert(res.toString());
    });

  }
}
