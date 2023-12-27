import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReportsRoutingModule } from './reports-routing.module';
import { ReportListComponent } from './report-list/report-list.component';
import { SharedModule } from 'src/app/presentation/shared/shared.module';
import { ReportDetailComponent } from './report-detail/report-detail.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    ReportsRoutingModule
  ],
  declarations: [ReportListComponent, ReportDetailComponent],
  exports:[]
})
export class ReportsModule { }
