import { Component, OnInit, OnDestroy } from '@angular/core';
import { DriveService } from '../services/drive/drive.service';
import { Drive } from '../models/drive';
import { Observable, Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-drive-list',
  templateUrl: './drive-list.component.html',
  styleUrls: ['./drive-list.component.css'],
  providers: [DriveService]
})
export class DriveListComponent implements OnInit, OnDestroy {
  private _drives: Drive[];
  private _subscription: Subscription;

  constructor(private _service: DriveService) {
  }

  ngOnInit() {
    this._subscription =
      this._service.Drives
        .subscribe(data => {
          this._drives = data.filter(drive => drive.totalSpace > 0).sort((a, b) => {
            if (a.totalSpace > b.totalSpace) {
              return -1;
            }
            if (a.totalSpace < b.totalSpace) {
              return 1;
            }
            return 0;
          });
        });
  }

  ngOnDestroy(): void {
    this._subscription.unsubscribe();
  }

  formatBytes(bytes, decimals): string {
    if (bytes === 0) { return '0 Bytes'; }
    const k = 1024;
    const dm = decimals || 2;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
  }

  usedPercent(drive: Drive) {
    return Number((drive.usedSpace / drive.totalSpace * 100).toFixed(1));
  }
}
