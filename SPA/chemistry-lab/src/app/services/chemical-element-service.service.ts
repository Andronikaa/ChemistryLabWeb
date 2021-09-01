import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core'
import { ChemicalElement } from '../common/chemicalElement';
import { GroupedChemicalElements } from '../common/groupedChemicalElements';
@Injectable({
  providedIn: 'root'
})
export class ChemicalElementServiceService {

  constructor(private http: HttpClient) { }

  getElements(){
    return this.http.get<GroupedChemicalElements[]>("https://localhost:44349/api/grouped-chemistry-elements");
  }
}
