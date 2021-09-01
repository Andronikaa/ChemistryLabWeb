import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChemicalElementsComponent } from './chemical-elements.component';

describe('ChemicalElementsComponent', () => {
  let component: ChemicalElementsComponent;
  let fixture: ComponentFixture<ChemicalElementsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChemicalElementsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChemicalElementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
