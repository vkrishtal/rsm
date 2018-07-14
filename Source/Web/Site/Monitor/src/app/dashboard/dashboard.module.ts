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

import { ProcessService } from './services/process/process.service';
import { RamService } from './services/ram/ram.service';
import { DriveService } from './services/drive/drive.service';
import { DriveUsageComponent } from './drive-usage/drive-usage.component';
import { DriveListComponent } from './drive-list/drive-list.component';

import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
registerLocaleData(en);

import { NgxChartsModule } from '@swimlane/ngx-charts';

@NgModule({
  imports: [
    CommonModule,
    DashboardRoutingModule,
    HttpModule,
    HttpClientModule,
    NgxChartsModule,
    NgZorroAntdModule
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
    DriveService,
    { provide: NZ_I18N, useValue: en_US }
  ]
})
export class DashboardModule { }
