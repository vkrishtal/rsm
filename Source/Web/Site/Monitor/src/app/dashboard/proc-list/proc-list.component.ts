import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';

import { Process } from '../models/process';
import { interval } from 'rxjs';

import { ProcessService } from '../services/process/process.service';

@Component({
  selector: 'app-proc-list',
  templateUrl: './proc-list.component.html',
  styleUrls: ['./proc-list.component.css']
})
export class ProcListComponent implements OnInit {

  private columns: string[] = ['pid', 'name', 'status', 'user'];
  private dataSource: MatTableDataSource<Process>;

  @ViewChild(MatPaginator)
  private paginator: MatPaginator;

  @ViewChild(MatSort)
  private sort: MatSort;

  constructor(private service: ProcessService) {

  }

  ngOnInit() {
    this.dataSource = new MatTableDataSource();
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
