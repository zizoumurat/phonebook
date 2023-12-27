import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IContactInformationRepository } from "../core/repositories/IContact-info.repository";
import { IContactInformationService } from "../core/services/IContact-info.service";
import { ContactInformationModel } from "../core/domain/contact-info.mode";

@Injectable({
    providedIn: 'root',
})
export class ContactInformationService extends IContactInformationService {
    constructor(private repo: IContactInformationRepository) {
        super();
    }
    override create(data: ContactInformationModel): Observable<any> {
        return this.repo.create(data);
    }
    override delete(id: string): Observable<any> {
        return this.repo.delete(id);
    }
}
