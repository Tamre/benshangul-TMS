export interface Zone {
    regionId: number;
    name: string;
    localName: string;
    code: string;
    localCode: string;
    suffix: string; // Corrected property name from "seffix" to "suffix"
    localSuffix: string;
    isCity: boolean; // Corrected type from "true" to "boolean"
    createdById: string;
    id: number;
    regionName: string;
    isActive: boolean; // Corrected type from "true" to "boolean"
  }
  