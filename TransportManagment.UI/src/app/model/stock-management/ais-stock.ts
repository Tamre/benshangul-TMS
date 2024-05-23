export interface AisStockGetDto {
    id:string;
    aisNo:number;
    isActive:boolean;
    stockTypeId:number;
    regionId:number;
    toZoneId:number;
    createdById:string;
}

export interface AisStockPostDto {
    stockTypeId: number;
    regionId: number;
    toZoneId: number;
    createdById: string;
    fromAISNo: number;
    toAISNo: number;

}