import { NgModule } from "@angular/core";
import { IPersonRepository } from "../core/repositories/IPerson.repository";
import { PersonRepository } from "../data/repository/person.repository";
import { IPersonService } from "../core/services/IPerson.service";
import { PersonService } from "./person.service";
import { IContactInformationRepository } from "../core/repositories/IContact-info.repository";
import { ContactInformationRepository } from "../data/repository/contact-info.repository";
import { IContactInformationService } from "../core/services/IContact-info.service";
import { ContactInformationService } from "./contact-info.service";
import { IReportRepository } from "../core/repositories/IReport.repository";
import { ReportRepository } from "../data/repository/report.repository";
import { IReportService } from "../core/services/IReport.service";
import { REportService } from "./report.service";

@NgModule({
    providers: [
        { provide: IPersonRepository, useClass: PersonRepository },
        { provide: IPersonService, useClass: PersonService },

        { provide: IContactInformationRepository, useClass: ContactInformationRepository },
        { provide: IContactInformationService, useClass: ContactInformationService },

        { provide: IReportRepository, useClass: ReportRepository },
        { provide: IReportService, useClass: REportService },
    ],
})
export class ServiceModule {}
