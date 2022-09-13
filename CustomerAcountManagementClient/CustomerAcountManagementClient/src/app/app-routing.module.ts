import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Router, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { HomePageComponent } from './modules/home-page/home-page.component';

const routes: Routes = [
  { path: 'homePage', component: HomePageComponent },
  { path: 'acount',loadChildren: () => import('./modules/acount/acount.module')
  .then(m => m.AcountModule),
  pathMatch: 'prefix' },
  {path:'transaction',loadChildren:()=>import('./modules/transaction/transaction.module')
.then(m=>m.TransactionModule)} 
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
