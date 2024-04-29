export interface VehicleTypeGetDto {
    id: number;
    name: string;
    localName: string;
    vehicleCategoryId: number;
    createdById: string;
    rowStatus:number;
    
}
export interface VehicleTypePostDto {
    name: string;
    localName: string;
    vehicleCategoryId: number;
    createdById: string;
    //isActive:Boolean;
}