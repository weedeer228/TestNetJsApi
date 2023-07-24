import { Component } from "@angular/core";
import { ICompany } from '../shared/Models/company-model';
import { CompanyService } from "../shared/companies-service";

@Component({
  selector: 'companies-overview',
  templateUrl: './companies-overview.component.html',
  styleUrls: ['./companies-overview.component.css']
})
export class CompaniesOverviewComponent {
  companies: ICompany[] = [];

  constructor(private companyService: CompanyService) { }

  ngOnInit(): void {
    this.companyService.createMock().subscribe(_ => {

      this.companyService.getCompanies().subscribe((data) => {
        this.companies = data as ICompany[];
        console.log(this.companies);
      });
    })

  }

}
