import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RamUsageComponent } from './ram-usage.component';

describe('RamUsageComponent', () => {
  let component: RamUsageComponent;
  let fixture: ComponentFixture<RamUsageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RamUsageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RamUsageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
