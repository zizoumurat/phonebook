import { ContactInformationModel } from "./contact-info.mode";

export class PersonDetailModel {
    id: string;
    firstName: string;
    lastName: string;
    company: string;

    contactInformation: ContactInformationModel[]
}
