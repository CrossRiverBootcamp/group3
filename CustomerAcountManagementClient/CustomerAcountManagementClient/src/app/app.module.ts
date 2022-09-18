import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AcountModule } from './modules/acount/acount.module';
import { HomePageComponent } from './modules/home-page/home-page.component';
import{MaterialModule} from './modules/material/material/material.module';
import { NotFoundPageComponent } from './modules/not-found-page/not-found-page.component';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    NotFoundPageComponent,  


  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AcountModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  
})
export class AppModule { }
