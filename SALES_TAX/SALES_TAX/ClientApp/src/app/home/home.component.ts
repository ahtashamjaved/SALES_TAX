import { Component, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';
import { SalesTaxService } from 'src/app/services/sales-tax.service';
import { Category } from '../models/category';
import { SalesItem } from '../models/sales-item';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent  {
  @ViewChild(DxDataGridComponent, { static: false }) dataGrid: DxDataGridComponent;
  totalAmount: number = 0;
  salesList:any=[]
  salesItems: any = [];
  categories: Category[];
  products: SalesItem[];
  model: SalesItem;
  error: any = {}
  showSalesTaxPopup: boolean = false;
  constructor(private service: SalesTaxService) {
    service.GetCategories().subscribe((s: Category[]) => {
      this.categories = s;
      console.log(this.products);
    }, error => console.error(error));

    service.GetProducts().subscribe((s: SalesItem[]) => {
      this.products = s;
      console.log(this.products);
    }, error => console.error(error));

  }
  public isValid(form: any, model: any) {
    model.Invalid = !form.instance.validate().isValid;
  }

  addItem(close: boolean = false, form: any) {
   this. model.Invalid = !form.instance.validate().isValid;
    if (!this.model.Invalid) {
      let product: SalesItem[] = this.products.filter(x => x.id == this.model.id);

      this.model.price = product[0].price;
      this.model.name = product[0].name;
      this.salesList.push(Object.assign({}, this.model));
      this.model = {}
      if (close) {
        this.service.Calculate(this.salesList).subscribe(s => {
          this.salesList = s.item;
          this.showSalesTaxPopup = false;
          this.totalAmount = s.total;
        })
      }
    }
  }

  public OnClosePopup(form: any) {
    this.showSalesTaxPopup = false;
    if (this.salesList != undefined && this.salesList.length > 0) {
      this.service.Calculate(this.salesList).subscribe(s => {
        this.salesList = s.item;
        this.showSalesTaxPopup = false;
      })
    } else {
      this.showSalesTaxPopup = false;
    }
  }
  clearFilter() {
    this.dataGrid.instance.clearFilter();
  }
  public addNewItem() {


    this.model = {};
    this.showSalesTaxPopup = true;
 
  }
  public editItem(model:any) {
 

    this.model = Object.assign({}, model);
    this.showSalesTaxPopup = true;
   
  }
  onSelectionChanged(event: any, id: number) {
    debugger;
    let product: SalesItem[] = this.products.filter(x => x.id == id);
    if (product != null && product != undefined && product.length > 0) {
      this.model.price = product[0].price;
      this.model.itemCategoryId = product[0].itemCategoryId;
    }
  }
  onToolbarPreparing(e:any) {

    e.toolbarOptions.items.unshift(
      {
        location: 'after',
        widget: 'dxButton',
        options: {
          text: 'Add New Item',
          icon:'add',

          onClick: this.addNewItem.bind(this)
        }
      
      
      },


    );
  }

}
