import { group } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { ChemicalElement } from 'src/app/common/chemicalElement';
import { GroupedChemicalElements } from 'src/app/common/groupedChemicalElements';
import { ChemicalElementServiceService } from 'src/app/services/chemical-element-service.service';

@Component({
  selector: 'chemical-elements',
  templateUrl: './chemical-elements.component.html',
  styleUrls: ['./chemical-elements.component.css']
})
export class ChemicalElementsComponent implements OnInit {

  groupedChemicalElements!: GroupedChemicalElements[];
  groups: number[] = [];

  constructor(private chemicalElementsService : ChemicalElementServiceService ) { }

  ngOnInit(): void {
    this.getChemicalElements();
  }

  getChemicalElements() {
    this.chemicalElementsService.getElements().subscribe(chemicals => {
      this.groupedChemicalElements = chemicals;

      for(let i = 1; i < chemicals.length; i ++){
        this.groups.push(i);
      }
    })
  }
}
