export interface PlateTypeGetDto {
    id: number;
    name: string;
    localName: string;
    code: string;
    regionList: string;
    createdById: string;
    isActive:Boolean;
    
}
export interface PlateTypePostDto {
    name: string;
    localName: string;
    code: string;
    regionList: string;
    createdById: string;
    isActive:Boolean;
}