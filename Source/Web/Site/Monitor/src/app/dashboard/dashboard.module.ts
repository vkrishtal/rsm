import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SystemInformationComponent } from './system-information/system-information.component';
import { RamUsageComponent } from './ram-usage/ram-usage.component';
import { CpuUsageComponent } from './cpu-usage/cpu-usage.component';
import { ProcListComponent } from './proc-list/proc-list.component';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatBadgeModule } from '@angular/material/badge';
import { MatListModule } from '@angular/material/list';

import { ProcessService } from './services/process/process.service';
import { RamService } from './services/ram/ram.service';
import { DriveService } from './services/drive/drive.service';
import { DriveUsageComponent } from './drive-usage/drive-usage.component';
import { DriveListComponent } from './drive-list/drive-list.component';

import { NgxChartsModule } from '@swimlane/ngx-charts';

@NgModule({
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MatButtonModule,
    MatCardModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatInputModule,
    HttpModule,
    HttpClientModule,
    MatBadgeModule,
    MatListModule,
    NgxChartsModule
  ],
  declarations: [
    DashboardComponent,
    SystemInformationComponent,
    RamUsageComponent,
    CpuUsageComponent,
    ProcListComponent,
    DriveUsageComponent,
    DriveListComponent],
  providers: [
    ProcessService,
    RamService,
    DriveService
  ]
})
export class DashboardModule { }
