import { Component, Input } from "@angular/core";
import { ICompany } from '../shared/Models/company-model';
import { CompanyService } from '../shared/companies-service';
import { ActivatedRoute, Router } from "@angular/router";


@Component({
    selector: "company-details",
    templateUrl: "company-details.component.html",
    styleUrls: ['company-details.css']
})
export class CompanyDetailsComponent {
    id!: number;
    companyDetails!: ICompany;

    constructor(private companyService: CompanyService, private route: ActivatedRoute) {

    }

    ngOnInit(): void {
        this.id = this.route.snapshot.params['id'];
        this.companyService.getCompany(this.id).subscribe(data => {
            this.companyDetails = data as ICompany;
        });
        //console.log(this.companyDetails);
    }
}