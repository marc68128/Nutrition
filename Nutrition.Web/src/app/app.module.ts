import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './components/app/app.component';
import { MealGeneratorComponent } from './components/meal-generator/meal-generator.component';
import { LoaderComponent } from './components/loader/loader.component';

import { LoaderService } from './services/loader/loader.service';
import { LoaderInterceptor } from './services/loader/loader.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    MealGeneratorComponent,
    LoaderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    LoaderService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
