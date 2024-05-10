export interface VehicleTypeGetDto {
    id: number;
    name: string;
    localName: string;
    vehicleCategoryId: number;
    createdById: string;
    rowStatus:number;
    categoryName:string;
    
}
export interface VehicleTypePostDto {
    name: string;
    localName: string;
    vehicleCategoryId: number;
    createdById: string;
    //isActive:Boolean;
}