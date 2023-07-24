import { Component, Input } from "@angular/core";
import { ICompany } from "src/app/Companies/shared/Models/company-model";
import { CompanyService } from '../../../shared/companies-service';


@Component({
  selector: 'company-history-part',
  templateUrl: './history-part.component.html',


})
export class CompanyHistoryPartComponent {
  @Input() currentCompany!: ICompany;

  constructor(private companyService: CompanyService) { }

  reloadData(): void {
    this.companyService.updateCompany(this.currentCompany);
  }



  getOrderCity(currentOrder: any): string {
    // if(order.city['$ref']==this.currentCompany.city['$id'])
    //     return this.currentCompany.city.name;
    // else
    //     return order.city.name;
    if (currentOrder.city.name !== undefined)
      return currentOrder.city.name;
    var id = currentOrder.city['$ref']
    var values = this.currentCompany.history['$values'] as any[];
    for (var order in values) {
      var or = (order as any)
      if (or.city === undefined)
        continue
      if (id == or.city['$id'])
        return or.city.name;
    }
    return this.currentCompany.city.name;
  }
}
