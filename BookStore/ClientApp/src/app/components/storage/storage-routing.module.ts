import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StorageComponent } from './storage.component';
import { BookItemComponent } from './book-item/book-item.component';
import { ChatComponent } from './chat/chat.component';
import { BookListComponent } from './book-list/book-list.component';
import { AuthGuardService as AuthGuard } from 'src/app/shared/services/auth-guard.service';

const routes: Routes = [
  {
    path: '', component: StorageComponent, children: [
      { path: 'Books', component: BookListComponent, canActivate: [AuthGuard]},
      { path: 'Book/:id', component: BookItemComponent, canActivate: [AuthGuard]},
      { path: 'Chat', component: ChatComponent, canActivate: [AuthGuard]}
    ],
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class StorageRoutingModule { }