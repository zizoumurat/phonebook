import { Observable } from "rxjs";
import { ContactInformationModel } from "../domain/contact-info.mode";

export abstract class IContactInformationRepository {
    abstract create(data: ContactInformationModel): Observable<any>;
    abstract delete(personId: string, id: string): Observable<any>;
}