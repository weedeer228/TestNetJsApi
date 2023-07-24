import { IEmployee } from "./employee-model";
import { INote } from "./note-model";
import { IOrder } from "./order-model";

export interface ICompany{
    id:number;
    name:string;
    city:any;
    state:string;
    phone:string;
    history:any
    notes:any;
    employees:any
    currentEmployee:any;
    
}