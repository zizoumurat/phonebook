import { DetailModel } from "./detail.model";

export class ReportDetailModel {
    id: number;
    requestDate: Date;
    createdDate: Date;
    isComplated: boolean;

    details: DetailModel[]
}