import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

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

import { ProcessService } from './services/process/process.service';
import { RamService } from './services/ram/ram.service';

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
    MatInputModule
  ],
  declarations: [
    DashboardComponent,
    SystemInformationComponent,
    RamUsageComponent,
    CpuUsageComponent,
    ProcListComponent],
  providers: [
    ProcessService,
    RamService
  ]
})
export class DashboardModule { }
