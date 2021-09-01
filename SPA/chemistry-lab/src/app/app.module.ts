import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WelcomePageComponent } from './components/welcome-page/welcome-page.component';
import { ChemicalElementsComponent } from './components/chemical-elements/chemical-elements.component';
import { HttpClientModule } from '@angular/common/http';
import { CompoundsComponent } from './components/compounds/compounds.component';

@NgModule({
  declarations: [
    AppComponent,
    WelcomePageComponent,
    ChemicalElementsComponent,
    CompoundsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
