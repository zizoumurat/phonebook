import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IPersonService } from "../core/services/IPerson.service";
import { PersonModel } from "../core/domain/person.model";
import { IPersonRepository } from "../core/repositories/IPerson.repository";
import { PersonDetailModel } from "../core/domain/person-detail.model";

@Injectable({
    providedIn: 'root',
})
export class PersonService extends IPersonService {
    constructor(private repo: IPersonRepository) {
        super();
    }

    override getList(): Observable<PersonModel[]> {
        return this.repo.getList();
    }
    override getById(id: string): Observable<PersonDetailModel> {
        return this.repo.getById(id);
    }
    override create(data: PersonModel): Observable<any> {
        return this.repo.create(data);
    }
    override delete(id: string): Observable<any> {
        return this.repo.delete(id);
    }
}
