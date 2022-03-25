import { Injectable , Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../models/category';
import { map } from 'rxjs/operators';
import { observable } from 'rxjs';
import { SalesReceiptDto } from '../models/sales-receipt-dto';
import { SalesItem } from '../models/sales-item';

@Injectable({
  providedIn: 'root'
})
export class SalesTaxService {
  
  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {

  }

  public GetCategories() {
    return this.http.get<Category[]>(this.baseUrl + 'salesTax/GetCategories').pipe(map((result: any) => {
      return result;
    }));
  }


  public GetProducts() {
    return this.http.get<Category[]>(this.baseUrl + 'salesTax/GetProducts').pipe(map((result: any) => {
      return result;
    }));
  }
  public Calculate(items: SalesItem[]) {
    return this.http.post<SalesReceiptDto[]>(this.baseUrl + 'salesTax/Calculate',items).pipe(map((result: any) => {
      return result;
    }));
  }

}
