export interface VehicleSettingGetDto {
    id: number;
    vehicleSettingType: string;
    value: number;
    createdById: string;
    isActive:Boolean;
    
}
export interface VehicleSettingPostDto {
    vehicleSettingType: string;
    value: number;
    createdById: string;
    isActive:Boolean;
}