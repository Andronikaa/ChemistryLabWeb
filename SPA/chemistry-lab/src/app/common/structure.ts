import { SafeUrl } from "@angular/platform-browser";
import { element } from "./element";

export interface structure{
    commonName: string;
    contentImage: SafeUrl;
    customId?: string;
    molecularFormula: string;
    name: string;
    chemicalElements: element[];
}