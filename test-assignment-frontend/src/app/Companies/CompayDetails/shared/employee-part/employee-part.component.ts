import { Component, Input } from "@angular/core";
import { ICompany } from "src/app/Companies/shared/Models/company-model";
import { CompanyService } from '../../../shared/companies-service';


@Component({
    selector: 'company-employee-part',
    templateUrl: './employee-part.component.html',
    styleUrls:['employee-part.css']


})
export class CompanyEmployeePartComponent {
    @Input() currentCompany!: ICompany;
    employees:any

    ngOnInit(): void {
        this.employees = this.currentCompany.notes["$values"].map(v=>v.employee);
    }
}