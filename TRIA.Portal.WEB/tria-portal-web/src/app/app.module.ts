import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ApiService } from './service/api.service';
import { ProdutosFormComponent } from './produtos/produtos-form/produtos-form.component';
import { ProdutosListComponent } from './produtos/produtos-list/produtos-list.component';
import { ClienteFormComponent } from './clientes/cliente-form/cliente-form.component';
import { ClienteListComponent } from './clientes/cliente-list/cliente-list.component';
import { ConfirmModalComponent } from './shared/confirm-modal/confirm-modal.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AlertModalService } from './service/alert-modal.service';
import { AlertModalComponent } from './shared/alert-modal/alert-modal.component';
import { FormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { LoginComponent } from './account/login/login.component';
import { CreateAccountComponent } from './account/create-account/create-account.component';
import { HomeComponent } from './layout/home/home.component';
import { AuthenticationComponent } from './layout/authentication/authentication.component';
import { httpInterceptorProviders } from './http-interceptors';

@NgModule({
  declarations: [
    AppComponent,
    ProdutosFormComponent,
    ProdutosListComponent,
    ClienteFormComponent,
    ClienteListComponent,
    ConfirmModalComponent,
    AlertModalComponent,
    LoginComponent,
    CreateAccountComponent,
    HomeComponent,
    AuthenticationComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    NgxMaskModule.forRoot()
  ],
  providers: [ httpInterceptorProviders, ApiService,AlertModalService],
  bootstrap: [AppComponent],
  exports: [BsDropdownModule, TooltipModule, ModalModule, AlertModalComponent],
  entryComponents:[ConfirmModalComponent]
})
export class AppModule { }
