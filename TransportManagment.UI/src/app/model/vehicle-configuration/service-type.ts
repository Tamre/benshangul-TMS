export interface ServiceTypeGetDto {
    id: number;
    name: string;
    localName: string;
    serviceModule: string;
    listOfPlates: string;
    listOfAIS: string;
    createdById: string;
    isActive:Boolean;
    
}
export interface ServiceTypePostDto {
    name: string;
    localName: string;
    serviceModule: string;
    listOfPlates: string;
    listOfAIS: string;
    createdById: string;
    isActive:Boolean;
}