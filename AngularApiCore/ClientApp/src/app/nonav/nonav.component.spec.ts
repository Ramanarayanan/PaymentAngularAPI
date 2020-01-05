import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NonavComponent } from './nonav.component';

describe('NonavComponent', () => {
  let component: NonavComponent;
  let fixture: ComponentFixture<NonavComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NonavComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NonavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
