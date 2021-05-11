import { AuthGuard } from './account/shared/auth.guard';
import { CreateAccountComponent } from './account/create-account/create-account.component';
import { LoginComponent } from './account/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteFormComponent } from './clientes/cliente-form/cliente-form.component';
import { ClienteListComponent } from './clientes/cliente-list/cliente-list.component';
import { AuthenticationComponent } from './layout/authentication/authentication.component';
import { HomeComponent } from './layout/home/home.component';
import { ProdutosFormComponent } from './produtos/produtos-form/produtos-form.component';
import { ProdutosListComponent } from './produtos/produtos-list/produtos-list.component';

const routes: Routes = [


  {
    path: "",
    component: HomeComponent,
    children:[{
        path: "",
        component: ClienteListComponent
      },
      {
      path: "produtos",
      component: ProdutosListComponent
    },
    {
      path: "produtos/add/:id",
      component: ProdutosFormComponent
    },
    {
      path: "produtos/edit/:id",
      component: ProdutosFormComponent
    },
    {
      path: "clientes",
      component: ClienteListComponent
    },
    {
      path: "clientes/add/:id",
      component: ClienteFormComponent
    },
    {
      path: "clientes/edit/:id",
      component: ClienteFormComponent
    }],
    canActivate:[AuthGuard]
  },
  {
    path: "",
    component: AuthenticationComponent,
    children:[
      {path: "", redirectTo:'login', pathMatch:'full'},
      {path: "login", component: LoginComponent},
      {path: "create-account", component: CreateAccountComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
