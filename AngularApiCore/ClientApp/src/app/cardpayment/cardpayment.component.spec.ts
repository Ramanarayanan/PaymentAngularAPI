import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardpaymentComponent } from './cardpayment.component';

describe('CardpaymentComponent', () => {
  let component: CardpaymentComponent;
  let fixture: ComponentFixture<CardpaymentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardpaymentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardpaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
