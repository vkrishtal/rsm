import { Component, OnInit, ViewChild } from '@angular/core';
import { Process } from '../models/process';
import { interval } from 'rxjs';

import { ProcessService } from '../services/process/process.service';

@Component({
  selector: 'app-proc-list',
  templateUrl: './proc-list.component.html',
  styleUrls: ['./proc-list.component.css']
})
export class ProcListComponent implements OnInit {

  processes: Process[];

  constructor(private service: ProcessService) {
  }

  ngOnInit() {
    this.service.Processes.subscribe(p => {
      this.processes = p.filter(pr => pr.workingSet > 0 && pr.name === 'chrome');
    });
  }

  formatBytes(bytes, decimals): string {
    if (bytes === 0) { return '0 Bytes'; }
    const k = 1024;
    const dm = decimals || 2;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
  }
}
