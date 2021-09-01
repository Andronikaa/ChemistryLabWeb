import { Component, OnInit } from '@angular/core';
import { CompoundsServiceService } from 'src/app/services/compounds-service.service';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { structure } from 'src/app/common/structure';

@Component({
  selector: 'app-compounds',
  templateUrl: './compounds.component.html',
  styleUrls: ['./compounds.component.css']
})
export class CompoundsComponent implements OnInit {

  compoundsNames: string[] = [];
  compoundsGroups: string[] = [];
  structures: structure[] = [];
  checkedGroupItems: string[] = [];
  pagesList : number[] = [];
  image!: SafeUrl;

  constructor(private service : CompoundsServiceService, private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.getCompoundsName();
    this.getStructures(1, 10, ['Alkohol', 'Fenol']);
  }

  listCompoundGroups(index: number){
    this.checkedGroupItems = [];
    this.service.getCompoundsGroups(this.compoundsNames[index]).subscribe(groups => {
      this.compoundsGroups = groups;
    })
  }

  getStructures(pageNumber: number, pageSize: number, compoundGroups: string[]) {
    this.service.getStructures(pageNumber, pageSize, compoundGroups).subscribe(response =>{
      this.structures = response.structures;

      this.structures.forEach(structure => {
        if(structure.contentImage){
          let objectURL = 'data:image/png;base64,' + structure.contentImage;
          structure.contentImage = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        }
      });
      this.getCompoundCount(response.pages);
    });
  }

  onCheckboxChange(group: string){
    if(this.checkedGroupItems.includes(group)){
      const index = this.checkedGroupItems.indexOf(group);
      if (index > -1) {
        this.checkedGroupItems.splice(index, 1);
      }
      this.getStructures(1, 10, this.checkedGroupItems);
      return;
    }
    this.checkedGroupItems.push(group);
    this.getStructures(1, 10, this.checkedGroupItems);
  }

  getCompoundsName() {
    this.service.getCompoundsName().subscribe(names => {
      this.compoundsNames = names;
    })
  }

  getCompoundCount(elements: number) {
    this.pagesList = [];
    let pages = Math.ceil(elements / 10);
      for(let i = 1; i <= pages; i++ ){
        this.pagesList.push(i);
    }
  }

  changePage(page : any){
    this.getStructures(page, 10, this.checkedGroupItems);
  }
}
