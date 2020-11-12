import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StorageRoutingModule } from './storage-routing.module';
import { ChatComponent } from './chat/chat.component';
import { BookListComponent } from './book-list/book-list.component';
import { BookItemComponent } from './book-item/book-item.component';
import { StorageComponent } from './storage.component';
import { FormsModule } from '@angular/forms';
import { SidebarComponent } from 'src/app/shared/component/sidebar/sidebar.component';
import { FooterComponent } from 'src/app/shared/component/footer/footer.component';

@NgModule({
  declarations: [ChatComponent,
    StorageComponent,
    FooterComponent,
    SidebarComponent,
    BookListComponent,
    BookItemComponent],
  imports: [
    CommonModule,
    FormsModule,
    StorageRoutingModule
  ]
})
export class StorageModule { }
