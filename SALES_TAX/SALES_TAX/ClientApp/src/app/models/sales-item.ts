import { Category } from "./category";

export class SalesItem {

  public id?: number = 0;
  public name?: string = "";
  public price?: number = 0;
  public quantity?: number = 0;
  public total?: number = 0;
  public salesTax?: number = 0;
  public importTax?: number = 0;
  public imported?: boolean = false;
  public itemCategoryId?: number = 0;
  public itemCategory?: Category = null;
  public Invalid?: boolean = false;

}
