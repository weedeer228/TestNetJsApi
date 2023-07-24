import { Routes } from "@angular/router";
import { CompanyDetailsComponent } from "./Companies/CompayDetails/company-details.component";
import { CompaniesOverviewComponent } from "./Companies/CompaniesOverview/companies-overview.component";

export const appRoutes:Routes =[
    {
        path:'companies/:id',
        component:CompanyDetailsComponent
    },
    {
        path:'companies',
        component:CompaniesOverviewComponent
    },
    {
        path:'',
        component:CompaniesOverviewComponent,
        pathMatch:'full'
    },

]