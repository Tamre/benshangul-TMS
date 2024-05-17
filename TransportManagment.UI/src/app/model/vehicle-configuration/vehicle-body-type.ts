export interface VehicleBodyTypeGetDto {
    id: number;
    name: string;
    localName: string;
    vehicleTypeId: number;
    value:number;
    createdById: string;
    isActive:boolean;
    typeName:string;
    
}
export interface VehicleBodyTypePostDto {
    name: string;
    localName: string;
    vehicleTypeId: number;
    value:number;
    createdById: string; 
    isActive:boolean;
}