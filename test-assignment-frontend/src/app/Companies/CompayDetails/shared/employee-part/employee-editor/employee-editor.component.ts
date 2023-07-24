import { Component, Input } from "@angular/core";
import { ICompany } from "src/app/Companies/shared/Models/company-model";


@Component({
    selector: 'company-employee-editor-part',
    templateUrl: './employee-editor-part.component.html',


})
export class CompanyEmployeeEditorPartComponent {
    @Input() currentCompany!: ICompany;
    currentEmployee:any;

    ngOnInit(): void {
        console.log();
        this.currentEmployee = this.currentCompany.notes["$values"].map(v=>v.employee)[1];
    }
}