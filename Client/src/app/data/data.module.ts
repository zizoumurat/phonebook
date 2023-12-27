import { NgModule } from "@angular/core";

import {HttpClientModule} from '@angular/common/http';
import { ApiService } from "./api/api.service";

@NgModule({
    imports:[
        HttpClientModule
    ],
    providers: [
        {provide: ApiService, useClass: ApiService},
      ],
})
export class DataModule{}

