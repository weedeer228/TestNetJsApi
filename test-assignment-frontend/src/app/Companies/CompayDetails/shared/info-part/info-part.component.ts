import { Component, Input } from "@angular/core";
import { ICompany } from "src/app/Companies/shared/Models/company-model";
import { CompanyService } from '../../../shared/companies-service';
import { FormControl, FormGroup, Validators } from "@angular/forms";


@Component({
  selector: 'company-info-part',
  templateUrl: './info-part.component.html',


})
export class CompanyinfoPartComponent {
  @Input() currentCompany!: ICompany;
  isEditorMode: boolean = false;
  companyInfoForm: FormGroup = new FormGroup({
    name: new FormControl('', Validators.required),
    city: new FormControl('', Validators.required),
    state: new FormControl('', Validators.required)
  })

  companyCityName!: string;

  constructor(private companyService: CompanyService) { }

  saveChanges(): void {

    if(!this.companyInfoForm.valid) return;
    this.companyService.updateCompany(this.currentCompany).subscribe(data => {
      console.log(data);
      this.setCompanyInfo();

    });

    this.changeMode()
  }

  changeMode() {
    this.isEditorMode = !this.isEditorMode;
  }

  setCompanyInfo() {
    this.currentCompany.city = this.companyInfoForm.get('city')?.value;
    this.currentCompany.name = this.companyInfoForm.get('name')?.value;
    this.currentCompany.state = this.companyInfoForm.get('state')?.value;
    this.companyCityName = this.companyInfoForm.get('city')?.value;


  }

  setFormValues() {
    this.companyInfoForm.get('name')?.setValue(this.currentCompany.name);
    this.companyInfoForm.get('city')?.setValue(this.currentCompany.city['name']);
    this.companyInfoForm.get('state')?.setValue(this.currentCompany.state);


  }

  ngOnInit(): void {
    this.setFormValues();
    this.setCompanyInfo();

  }
}




