import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { ProdutsComponent } from './components/produts/produts.component';
import { DeleteProductComponent } from './components/delete-product/delete-product.component';
import { NewProductComponent } from './components/new-product/new-product.component';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { ShowSingleProductComponent } from './components/show-single-product/show-single-product.component';
import { ProdutService } from './services/produt.service';
import { AuthService } from './services/auth.service';
import { LoginUserComponent } from './components/login-user/login-user.component';
import { AuthGuard } from './auth.guard';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProdutsComponent,
    DeleteProductComponent,
    NewProductComponent,
    EditProductComponent,
    ShowSingleProductComponent,
    LoginUserComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'produtos', component: ProdutsComponent, canActivate:[AuthGuard] },
      { path: 'novo-produto', component: NewProductComponent, canActivate:[AuthGuard]},
      { path: 'edita-produto/:id', component: EditProductComponent, canActivate:[AuthGuard]},
      { path: 'mostra-produto/:id', component: ShowSingleProductComponent, canActivate:[AuthGuard]},
      { path: 'login', component: LoginUserComponent, canActivate:[AuthGuard]},
      { path: 'deleta-produto/:id', component: DeleteProductComponent, pathMatch: 'full', canActivate:[AuthGuard] },
    ])
  ],
  providers: [ProdutService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
