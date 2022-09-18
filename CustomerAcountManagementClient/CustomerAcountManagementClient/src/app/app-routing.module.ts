import { LoginComponent } from './modules/acount/login/login.component';
import { NotFoundPageComponent } from './modules/not-found-page/not-found-page.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Router, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { HomePageComponent } from './modules/home-page/home-page.component';

const routes: Routes = [
  { path: '', component: LoginComponent},
  { path: 'home-page', component: HomePageComponent },
  { path: 'acount',loadChildren: () => import('./modules/acount/acount.module')
  .then(m => m.AcountModule),
  pathMatch: 'prefix' },
  {path:'transaction',loadChildren:()=>import('./modules/transaction/transaction.module')
.then(m=>m.TransactionModule)} ,
{path: '**', component: NotFoundPageComponent }

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 
  public parameterValue!: string;

  constructor(
    private _router: Router,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {

}
}
