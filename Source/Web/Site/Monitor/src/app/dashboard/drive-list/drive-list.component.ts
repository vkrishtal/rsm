import { Component, OnInit, OnDestroy } from '@angular/core';
import { DriveService } from '../services/drive/drive.service';
import { Drive } from '../models/drive';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-drive-list',
  templateUrl: './drive-list.component.html',
  styleUrls: ['./drive-list.component.css'],
  providers: [DriveService]
})
export class DriveListComponent implements OnInit, OnDestroy {
  private _drivers: Drive[];
  private _subscription: Subscription;

  constructor(private _service: DriveService) {
  }

  ngOnInit() {
    this._subscription = this._service.drives.subscribe(data => {
      this._drivers = data;
    });
  }

  ngOnDestroy(): void {
    this._subscription.unsubscribe();
  }
}
