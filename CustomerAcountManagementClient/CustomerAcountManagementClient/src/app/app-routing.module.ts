import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './modules/home-page/home-page.component';

const routes: Routes = [
  { path: "", component: HomePageComponent },
  { path: 'login',loadChildren: () => import('./modules/acount/acount.module')
  .then(m => m.AcountModule) },
  {
    path: 'register', loadChildren: () => import('./modules/acount/acount.module')
      .then(m => m.AcountModule)
  },
  {path:'acountInfo',loadChildren:()=>import('./modules/acount/acount.module')
  .then(m => m.AcountModule)}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
