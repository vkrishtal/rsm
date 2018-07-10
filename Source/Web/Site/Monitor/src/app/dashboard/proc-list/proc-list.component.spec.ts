import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcListComponent } from './proc-list.component';

describe('ProcListComponent', () => {
  let component: ProcListComponent;
  let fixture: ComponentFixture<ProcListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProcListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
