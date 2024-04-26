export interface VehicleLookupGetDto {
    id: number;
    name: string;
    localName: string;
    vehicleLookupType: string;
    createdById: string;
    isActive:Boolean;
}
export interface VehicleLookupPostDto {
    name: string;
    localName: string;
    vehicleLookupType: string;
    createdById: string;
    isActive:Boolean;
}