import { Component, Input } from "@angular/core";


@Component({
    selector:'details-header',
    templateUrl:'./details-header.component.html',
    styleUrls:['details-header.css']

})
export class DetailsHeaderComponent{
@Input() name!:string
}