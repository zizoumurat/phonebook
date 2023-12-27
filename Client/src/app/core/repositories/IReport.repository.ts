import { Observable } from "rxjs";
import { ReportModel } from "../domain/report.model";
import { ReportDetailModel } from "../domain/report.detail.model";

export abstract class IReportRepository {
    abstract getList(): Observable<ReportModel[]>;
    abstract getById(id :number): Observable<ReportDetailModel>;
    abstract create(): Observable<any>;
    abstract delete(id :number): Observable<any>;
}