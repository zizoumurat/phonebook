import { Observable } from "rxjs";
import { PersonModel } from "../domain/person.model";
import { PersonDetailModel } from "../domain/person-detail.model";


export abstract class IPersonService {
    abstract getList(): Observable<PersonModel[]>;
    abstract getById(id :string): Observable<PersonDetailModel>;
    abstract create(data: PersonModel): Observable<any>;
    abstract delete(id :string): Observable<any>;
}
