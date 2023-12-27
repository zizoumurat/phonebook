import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { NotificationService } from 'src/app/core/services/notification.service';
import { MatDialog } from '@angular/material/dialog';
import { IReportService } from 'src/app/core/services/IReport.service';
import { HubService } from 'src/app/service/hub.service';
import { ReportDetailComponent } from '../report-detail/report-detail.component';


export interface PeriodicElement {
  name: string;
  lastName: string;
  company: string;
}

@Component({
  selector: 'app-report-list',
  templateUrl: './report-list.component.html',
  styleUrls: ['./report-list.component.css']
})

export class ReportListComponent implements OnInit {
  displayedColumns: string[] = ['requestDate', 'createdDate', 'isComplated', 'actions'];
  dataSource: any;

  @ViewChild(MatSort, { static: true })
  sort: MatSort = new MatSort;

  constructor(
    private notificationService: NotificationService,
    private titleService: Title,
    private dialog: MatDialog,
    private service: IReportService,
    private hubService: HubService
  ) { }

  ngOnInit() {
    this.titleService.setTitle('Raporlar');
    this.getList();
    this.hubService.notificationReceived.subscribe((data) => {
      this.notificationService.openSnackBar(data);
      this.getList();
    });
  }

  getList() {
    this.service.getList()
      .pipe()
      .subscribe(x => {
        this.dataSource = new MatTableDataSource(x);
        this.dataSource.sort = this.sort;
      })
  }

  openDetail(id: number): void {
    const dialogRef = this.dialog.open(ReportDetailComponent, {
      data: id,
      width: '400px',
      disableClose: false
    });
  }

  delete(id: number): void {
    this.service.delete(id)
      .pipe()
      .subscribe(_ => {
        this.getList();
      });
  }

  createNewReport(): void {
    this.service.create()
      .pipe()
      .subscribe(x => {
        this.notificationService.openSnackBar("Talebiniz işleniyor...");
      });
  }

}
