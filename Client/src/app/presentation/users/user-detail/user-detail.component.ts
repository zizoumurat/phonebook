import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { NotificationService } from 'src/app/core/services/notification.service';
import { MatDialog } from '@angular/material/dialog';
import { IPersonService } from 'src/app/core/services/IPerson.service';
import { PersonModel } from 'src/app/core/domain/person.model';
import { ActivatedRoute } from '@angular/router';
import { AddContactComponent } from '../add-contact/add-contact.component';
import { IContactInformationService } from 'src/app/core/services/IContact-info.service';

export interface PeriodicElement {
  name: string;
  lastName: string;
  company: string;
}

@Component({
  selector: 'app-user-list',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  displayedColumns: string[] = ['phoneNumber', 'email', 'location', 'actions'];

  @ViewChild(MatSort, { static: true })
  dataSource: any;
  sort: MatSort = new MatSort;
  person: PersonModel;
  personId: "";

  constructor(
    private titleService: Title,
    private dialog: MatDialog,
    private personService: IPersonService,
    private contactService: IContactInformationService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.titleService.setTitle('Kişi Detayları');
    this.route.params.subscribe(params => {
      this.personId = params['id'];
      this.getPerson();
    });
  }

  getPerson() {
    this.personService.getById(this.personId)
      .pipe()
      .subscribe(x => {
        this.person = x;
        this.dataSource = new MatTableDataSource(x.contactInformation);
        this.dataSource.sort = this.sort;
      })
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddContactComponent, {
      data: this.personId,
      width: '640px',
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result)
        this.getPerson();
    });
  }

  delete(id: string) {
  
    this.contactService.delete(id)
      .pipe()
      .subscribe(x => {
        this.getPerson();
      })
  }
}
