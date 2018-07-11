import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DriveUsageComponent } from './drive-usage.component';

describe('DriveUsageComponent', () => {
  let component: DriveUsageComponent;
  let fixture: ComponentFixture<DriveUsageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DriveUsageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DriveUsageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
