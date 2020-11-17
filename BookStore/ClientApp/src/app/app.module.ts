import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { Router, RouterModule, Routes, CanActivate } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtModule } from "@auth0/angular-jwt";
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from 'src/app/shared/auth/token.interceptor';
import { FormsModule } from '@angular/forms';
import { MatSliderModule } from '@angular/material/slider';
import { SidebarComponent } from './shared/component/sidebar/sidebar.component';
import { FooterComponent } from './shared/component/footer/footer.component';
import { StorageComponent } from './components/storage/storage.component';
import { AccountComponent } from './components/account/account.component';

const routes: Routes = [
  { path: '', redirectTo: 'Account', pathMatch: 'full' },
  {
    path: '', children:
      [        
        { path: 'Storage',
        loadChildren: () => import('./components/storage/storage.module').then(m => m.StorageModule) },
        { path: 'Account',
        loadChildren: () => import('./components/account/account.module').then(m => m.AccountModule) }
      ]
  },
]

@NgModule({
  declarations: [
    AppComponent
  ],  
  imports: [
    BrowserModule,  
    RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' }),
    FormsModule, 
    HttpClientModule,
    MatSliderModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    JwtModule.forRoot({ config: {} })  
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }