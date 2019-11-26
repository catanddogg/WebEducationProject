import { GetAuthorViewItem } from './get-author.view';
import { GetCategoryViewItem } from './get-category.view';

export class BookViewModel{
    public bookId: number;
    public name: string;
    public path: string;
    public getAuthorViewItem: GetAuthorViewItem;
    public getCategoryViewItem : GetCategoryViewItem;
}