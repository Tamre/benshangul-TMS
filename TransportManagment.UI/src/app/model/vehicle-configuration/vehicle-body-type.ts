export interface VehicleBodyTypeGetDto {
    id: number;
    name: string;
    localName: string;
    vehicleTypeId: number;
    value:number;
    createdById: string;
    isActive:boolean;
    
}
export interface VehicleBodyTypePostDto {
    name: string;
    localName: string;
    vehicleTypeId: number;
    value:number;
    createdById: string; 
    isActive:boolean;
}