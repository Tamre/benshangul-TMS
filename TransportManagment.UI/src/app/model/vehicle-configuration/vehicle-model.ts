export interface VehicleModelGetDto {
    id: number;
    name: string;
    engineCapacity: number;
    noOfCylinder: number;
    horsePowerMeasure:string;
    markId:number;
    markName:string;
    createdById: string;
    rowStatus:number;
}
export interface VehicleModelPostDto {
    name: string;
    engineCapacity: number;
    noOfCylinder: number;
    horsePowerMeasure:string;
    markId:number;
    createdById: string;
    isActive:boolean;
}