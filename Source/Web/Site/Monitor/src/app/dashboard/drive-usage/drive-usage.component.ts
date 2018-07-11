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

  lineChartMulti = [
    {
        'name': 'Germany',
        'series': [
        {
            'name': '2010',
            'value': 700
        },
        {
            'name': '2011',
            'value': 750
        },
        {
            'name': '2012',
            'value': 775
        },
        {
            'name': '2013',
            'value': 725
        },
        {
            'name': '2014',
            'value': 750
        },
        {
            'name': '2015',
            'value': 800
        },
        {
            'name': '2016',
            'value': 860
        }
        ]
    }
  ];

  ngOnInit() {
  }
}
