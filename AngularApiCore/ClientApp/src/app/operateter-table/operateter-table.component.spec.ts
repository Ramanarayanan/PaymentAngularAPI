import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OperateterTableComponent } from './operateter-table.component';

describe('OperateterTableComponent', () => {
  let component: OperateterTableComponent;
  let fixture: ComponentFixture<OperateterTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OperateterTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OperateterTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
