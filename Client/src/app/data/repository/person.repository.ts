import { IPersonRepository } from "src/app/core/repositories/IPerson.repository";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiService } from "../api/api.service";
import { PersonModel } from "src/app/core/domain/person.model";
import { PersonDetailModel } from "src/app/core/domain/person-detail.model";

const endPoint = "person";

@Injectable()
export class PersonRepository extends IPersonRepository {
    constructor(
        private api: ApiService
    ) {
        super();
    }

    override getList(): Observable<PersonModel[]> {
        return this.api.get<PersonModel[]>(`${endPoint}`);
    }
    override getById(id: string): Observable<PersonDetailModel> {
        return this.api.get<PersonDetailModel>(`${endPoint}/${id}`);
    }
    override create(data: PersonModel): Observable<any> {
        return this.api.post(endPoint, data);
    }
    override delete(id: string): Observable<any> {
        return this.api.delete(`${endPoint}/${id}`);
    }
}