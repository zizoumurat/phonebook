import { IContactInformationRepository } from "src/app/core/repositories/IContact-info.repository";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "../api/api.service";
import { ContactInformationModel } from "src/app/core/domain/contact-info.mode";

const endPoint = "contactinformation";

@Injectable()
export class ContactInformationRepository extends IContactInformationRepository {
    constructor(
        private api: ApiService
    ) {
        super();
    }

    override create(data: ContactInformationModel): Observable<any> {
        return this.api.post(endPoint, data);
    }

    override delete(personId: string, id: string): Observable<any> {
        return this.api.delete(`${endPoint}/${personId}/${id}`);
    }
}