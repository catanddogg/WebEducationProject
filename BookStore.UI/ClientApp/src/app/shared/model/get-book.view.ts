import {GetAuthorViewItem} from 'src/app/shared/model/get-author.view';
import {GetCategoryViewItem} from 'src/app/shared/model/get-category.view';

export class GetBookById {
  public bookId: number;
  public name: string;
  public path: string;
  public getAuthorViewItem: GetAuthorViewItem;
  public getCategoryViewItem : GetCategoryViewItem;
}
