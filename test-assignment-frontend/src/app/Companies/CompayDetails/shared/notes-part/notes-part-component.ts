import { Component, Input } from "@angular/core";
import { ICompany } from "src/app/Companies/shared/Models/company-model";
import { CompanyService } from '../../../shared/companies-service';


@Component({
    selector: 'company-notes-part',
    templateUrl: './notes-part.component.html',


})
export class CompanyNotesPartComponent {
    @Input() currentCompany!: ICompany;

    constructor(private companyService: CompanyService) { }

    saveChanges(): void {
        this.companyService.updateCompany(this.currentCompany);
    }

    getEmployeeName(note: any) {
        var employee = note.employee;
        return employee.firstName + ' ' + employee.lastName;
    }
}