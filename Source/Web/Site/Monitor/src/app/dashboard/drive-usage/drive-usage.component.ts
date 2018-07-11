import { Component, OnInit, Input } from '@angular/core';
import { DriveService } from '../services/drive/drive.service';
import { Drive } from '../models/drive';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-drive-usage',
  templateUrl: './drive-usage.component.html',
  styleUrls: ['./drive-usage.component.css']
})
export class DriveUsageComponent implements OnInit {
  @Input()
  public drive: Drive;

  ngOnInit() {
  }
}
