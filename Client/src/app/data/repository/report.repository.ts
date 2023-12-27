import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IReportRepository } from "src/app/core/repositories/IReport.repository";
import { ApiService } from "../api/api.service";
import { ReportModel } from "src/app/core/domain/report.model";
import { ReportDetailModel } from "src/app/core/domain/report.detail.model";

const endPoint = "report";

@Injectable()
export class ReportRepository extends IReportRepository {
    constructor(
        private api: ApiService
    ) {
        super();
    }

    override getList(): Observable<ReportModel[]> {
        return this.api.get<ReportModel[]>(`${endPoint}`);
    }
    override getById(id: number): Observable<ReportDetailModel> {
        return this.api.get<ReportDetailModel>(`${endPoint}/${id}`);
    }
    override create(): Observable<any> {
        return this.api.post(endPoint, {});
    }
    override delete(id: number): Observable<any> {
        return this.api.delete(`${endPoint}/${id}`);
    }
}