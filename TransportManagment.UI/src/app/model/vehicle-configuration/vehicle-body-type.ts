export interface VehicleBodyTypeGetDto {
    id: number;
    name: string;
    localName: string;
    vehicleTypeId: number;
    value:number;
    createdById: string;
    rowStatus:number;
    
}
export interface VehicleBodyTypePostDto {
    name: string;
    localName: string;
    vehicleTypeId: number;
    value:number;
    createdById: string; 
    rowStatus:number;
}