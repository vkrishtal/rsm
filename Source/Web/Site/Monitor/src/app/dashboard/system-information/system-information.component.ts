import { Component, OnInit, OnDestroy } from '@angular/core';
import { SystemService } from '../services/system/system.service';
import { System } from '../models/system';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-system-information',
  templateUrl: './system-information.component.html',
  styleUrls: ['./system-information.component.css'],
  providers: [ SystemService ]
})
export class SystemInformationComponent implements OnInit, OnDestroy {
  private _system: Observable<System>;

  constructor(private _service: SystemService) {
  }

  ngOnInit() {
    this._system = this._service.System;
  }

  ngOnDestroy(): void {
  }
}
