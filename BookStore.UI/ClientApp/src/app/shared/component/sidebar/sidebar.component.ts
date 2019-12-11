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

  constructor(private router: Router) { }

  ngOnInit() {
    this.sidebarList = [];

    let books = new SidebarListView();
    books.image = 'fas fa-journal-whills';
    books.name = 'Books';
    books.rout = '/Home'

    this.sidebarList.push(books);

    let chat = new SidebarListView();
    chat.image = 'far fa-comments';
    chat.name = 'Chat';
    chat.rout = '/Chat';

    this.sidebarList.push(chat);

    let logOut = new SidebarListView();
    logOut.image = 'fas fa-door-open';
    logOut.name = 'Log Out'
    logOut.rout = '/';

    this.sidebarList.push(logOut);
  }

  navigationToLoginPage(){
    this.router.navigate(['/']);
  }
}