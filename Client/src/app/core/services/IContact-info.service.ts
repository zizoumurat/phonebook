import { Observable } from "rxjs";
import { ContactInformationModel } from "../domain/contact-info.mode";


export abstract class IContactInformationService {
    abstract create(data: ContactInformationModel): Observable<any>;
    abstract delete(id :string): Observable<any>;
}
