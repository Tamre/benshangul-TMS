export interface VehicleSettingGetDto {
    id: number;
    vehicleSettingType: number;
    value: number;
    createdById: string;
    isActive:Boolean;
    
}
export interface VehicleSettingPostDto {
    vehicleSettingType: number;
    value: number;
    createdById: string;
    isActive:Boolean;
}