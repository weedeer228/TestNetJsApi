import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { CompaniesOverviewComponent } from './Companies/CompaniesOverview/companies-overview.component';
import { OverviewComponent } from './headers/overview/overview-header.component';
import { MatIconModule } from '@angular/material/icon';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import { CompanyService } from './Companies/shared/companies-service';
import { HttpClientModule } from '@angular/common/http'
import { RouterModule } from '@angular/router';
import { CompanyDetailsComponent } from './Companies/CompayDetails/company-details.component';
import { appRoutes } from './routes';
import { DetailsHeaderComponent } from './headers/details/details-header.component';
import { CompanyinfoPartComponent } from './Companies/CompayDetails/shared/info-part/info-part.component';
import { CompanyHistoryPartComponent } from './Companies/CompayDetails/shared/history-part/history-part.component';
import { CompanyNotesPartComponent } from './Companies/CompayDetails/shared/notes-part/notes-part-component';
import { CompanyEmployeePartComponent } from './Companies/CompayDetails/shared/employee-part/employee-part.component';
import { CompanyEmployeeEditorPartComponent } from './Companies/CompayDetails/shared/employee-part/employee-editor/employee-editor.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    OverviewComponent,
    CompaniesOverviewComponent,
    CompanyDetailsComponent,
    DetailsHeaderComponent,
    CompanyinfoPartComponent,
    CompanyHistoryPartComponent,
    CompanyNotesPartComponent,
    CompanyEmployeePartComponent,
    CompanyEmployeeEditorPartComponent,

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatIconModule,
    FontAwesomeModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule,


  ],
  providers: [CompanyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
