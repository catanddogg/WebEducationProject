import { Component, OnInit } from '@angular/core';
import { SidebarListView } from '../../model/sidebar-list.view';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  private sidebarList: SidebarListView[];
  private selectItem: string;

  constructor(private router: Router) { }

  ngOnInit() {
    this.sidebarList = [];

    let books = new SidebarListView();
    books.image = 'fas fa-journal-whills';
    books.name = 'Books';
    books.rout = '/Storage/Books';

    this.sidebarList.push(books);

    let chat = new SidebarListView();
    chat.image = 'far fa-comments';
    chat.name = 'Chat';
    chat.rout = '/Storage/Chat';

    this.sidebarList.push(chat);

    let logOut = new SidebarListView();
    logOut.image = 'fas fa-door-open';
    logOut.name = 'Log Out'
    logOut.rout = '/Account/';

    this.sidebarList.push(logOut);
  }

  navigation(item: SidebarListView) {
    this.router.navigate([item.rout]);
    item.select = 'item-select';
    if (this.selectItem) {
      this.sidebarList.forEach(sidebarItem => {
        if (sidebarItem.name === this.selectItem) {
          sidebarItem.select = 'item-not-select';
        }
      });
    }
    this.selectItem = item.name;
    if (item.name === 'Log Out') {
      localStorage.clear();
    }
  }
}