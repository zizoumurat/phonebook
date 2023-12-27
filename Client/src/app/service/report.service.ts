import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IReportService } from "../core/services/IReport.service";
import { IReportRepository } from "../core/repositories/IReport.repository";
import { ReportModel } from "../core/domain/report.model";
import { ReportDetailModel

 } from "../core/domain/report.detail.model";
@Injectable({
    providedIn: 'root',
})
export class REportService extends IReportService {
    constructor(private repo: IReportRepository) {
        super();
    }

    override getList(): Observable<ReportModel[]> {
        return this.repo.getList();
    }
    override getById(id: number): Observable<ReportDetailModel> {
        return this.repo.getById(id);
    }
    override create(): Observable<any> {
        return this.repo.create();
    }
    override delete(id: number): Observable<any> {
        return this.repo.delete(id);
    }
}
