import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChemicalElementsComponent } from './components/chemical-elements/chemical-elements.component';
import { CompoundsComponent } from './components/compounds/compounds.component';
import { WelcomePageComponent } from './components/welcome-page/welcome-page.component';

const routes: Routes = [
  { path: 'chemical-elements', component: ChemicalElementsComponent },
  { path: 'compounds', component: CompoundsComponent },
  { path: '', component: WelcomePageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
