import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { DetailModel } from 'src/app/core/domain/detail.model';
import { ReportDetailModel } from 'src/app/core/domain/report.detail.model';
import { IReportService } from 'src/app/core/services/IReport.service';

@Component({
    selector: 'app-report-detail',
    templateUrl: './report-detail.component.html',
    styleUrls: ['./report-detail.component.css']
})

export class ReportDetailComponent implements OnInit {
    displayedColumns: string[] = ['location', 'personCount', 'phoneNumberCount'];

    dataSource: MatTableDataSource<DetailModel>;
    reportId : number;
    report: ReportDetailModel;

    constructor(
        public dialog: MatDialog,
        private service: IReportService,
        @Inject(MAT_DIALOG_DATA) public data: number,
    ) { }


    ngOnInit(): void {
        this.getReport();
    }

    getReport() {
        this.service.getById(this.data)
          .pipe()
          .subscribe(x => {
            this.report = x;
            this.dataSource = new MatTableDataSource(x.details);
          })
      }

    closeDialog(): void {
        this.dialog.closeAll();
    }
}