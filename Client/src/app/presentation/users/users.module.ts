import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UserListComponent } from './user-list/user-list.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { AddUserComponent } from './add-user/add-user.component';
import { AddContactComponent } from './add-contact/add-contact.component';
import { SharedModule } from 'src/app/presentation/shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    UsersRoutingModule
  ],
  declarations: [UserListComponent,UserDetailComponent, AddUserComponent, AddContactComponent],
  exports:[]
})
export class UsersModule { }
