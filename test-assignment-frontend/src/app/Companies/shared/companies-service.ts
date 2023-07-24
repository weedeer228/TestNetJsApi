import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ICompany } from './Models/company-model';
import { Observable, of, catchError, map } from 'rxjs';



@Injectable()
export class CompanyService {
  constructor(private client: HttpClient) {

  }

  private handleError<T>(operation: string = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log(error);
      return of(result as T);
    }
  }
  // getCompanies(){
  //     return this.client.get('/api/Companies').pipe(data=>);
  // }
  getCompanies(): Observable<ICompany[]> {
    return this.client.get<Object>('/api/Companies').pipe(map(v => v["$values"]));
  }

  getCompany(id: number): Observable<ICompany> {
    return this.client.get<ICompany>('/api/companies/id?id=' + id);
  }

  updateCompany(company: ICompany) {
    console.log(company);
    return this.client.post('/api/update/company', {
      Id: company.id,
      Name: company.name,
      City: company.city,
      State: company.state,
      Phone: company.phone,
      History: company.history,
      Employees: company.notes["$values"].map(v => v.employee),
      Notes: company.notes,
    });
  }

  createMock() {
    return this.client.post("/api/Create/Mock", undefined);
  }

  convertToApirequest() {

  }
}


