import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Router, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { HomePageComponent } from './modules/home-page/home-page.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  {path:'home-page',component:HomePageComponent},
  { path: 'acount',loadChildren: () => import('./modules/acount/acount.module')
  .then(m => m.AcountModule),
  pathMatch: 'prefix' },
  { path: 'acount',loadChildren: () => import('./modules/acount/acount.module')
  .then(m => m.AcountModule),
  pathMatch: 'prefix' }
 
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

    // this.parameterValue = this._activatedRoute.snapshot.params.parameter
    //this._router.navigate(['first/4'])
    //this.parameterValue = this._activatedRoute.snapshot.params.parameter
}
}
