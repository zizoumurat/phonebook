import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NGXLogger } from 'ngx-logger';
import { Title } from '@angular/platform-browser';
import { NotificationService } from 'src/app/core/services/notification.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddUserComponent } from '../add-user/add-user.component';
import { IPersonService } from 'src/app/core/services/IPerson.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  displayedColumns: string[] = ['firstName', 'lastName', 'company', 'actions'];

  @ViewChild(MatSort, { static: true })
  sort: MatSort = new MatSort;
  dataSource: any;

  constructor(
    private personService: IPersonService,
    private notificationService: NotificationService,
    private titleService: Title,
    private dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit() {
    this.titleService.setTitle('Kişiler');

    this.getList();
  }

  getList() {
    this.personService.getList()
      .pipe()
      .subscribe(x => {
        this.dataSource = new MatTableDataSource(x);
        this.dataSource.sort = this.sort;
      })
  }

  delete(id: string) {
    this.personService.delete(id)
      .pipe()
      .subscribe(x => {
        this.getList();
      })
  }

  goToDetail(id: string) {
    this.router.navigateByUrl(`/users/${id}`);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddUserComponent, {
      width: '640px', disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result)
        this.getList();
    });
  }

}
