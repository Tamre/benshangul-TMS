export interface ServiceYearGetDto {
    id: number;
    isActive:Boolean;
    name: string;
    localName: string; 
    serviceModule: string;
    listOfPlates: string;
    listOfAIS: string;
    createdById: string;
    
}
export interface ServiceYearPostDto {
    name: string;
    localName: string;
    serviceModule: string;
    listOfPlates: string;
    listOfAIS: string;
    createdById: string;
    //isActive:Boolean;
}