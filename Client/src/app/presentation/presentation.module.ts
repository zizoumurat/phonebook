import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from "./shared/shared.module";
import { UsersModule } from "./users/users.module";
import { ReportsModule } from "./reports/reports.module";

@NgModule({
  declarations: [
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    SharedModule,
    UsersModule,
    ReportsModule
  ],

  exports: [

  ],

  providers: [

  ]
})

export class PresentationModule { }