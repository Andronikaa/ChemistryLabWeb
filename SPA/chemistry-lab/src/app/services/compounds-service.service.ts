import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { pagedStructure } from '../common/pagedStructures';
import { structure } from '../common/structure';

@Injectable({
  providedIn: 'root'
})
export class CompoundsServiceService {

  constructor(private http: HttpClient) { }

  getCompoundsName(){
    return this.http.get<string[]>("https://localhost:44349/api/compounds-names");
  }

  getCompoundsGroups(compoundName : string){
    let params = new HttpParams().set('groupName', compoundName);
    return this.http.get<string[]>("https://localhost:44349/api/compounds-groups", {params : params});
  }

  getCompoundsCount(){
    return this.http.get<number>("https://localhost:44349/api/compounds-count");
  }

  getStructures(pageNumber: number, pageSize: number, compoundGroups: string[]){
    let params = new HttpParams()
    .set('PageNumber', pageNumber)
    .set('PageSize', pageSize);
    compoundGroups.forEach(group => {
      params = params.append('CompoundGroups', group)
    })
    return this.http.get<pagedStructure>("https://localhost:44349/api/structures", {params : params});
  }
}
