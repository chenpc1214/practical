import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepComponentComponent } from './dep-component.component';

describe('DepComponentComponent', () => {
  let component: DepComponentComponent;
  let fixture: ComponentFixture<DepComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepComponentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DepComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
