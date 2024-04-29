export interface ManufactureYearGetDto {
    id: number;
    isActive:Boolean;
    name: string;
    localName: string;
    listOfCountries:string;
    value: string;
    createdById: string;
    
}
export interface ManufactureYearPostDto {
    name: string;
    localName: string;
    value: string;
    listOfCountries:string;
    createdById: string;
    isActive:Boolean;
}