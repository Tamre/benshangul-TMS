export interface OrcStockGetDto {
    id:string;
    orcNo:number;
    isActive:boolean;
    stockTypeId:number;
    regionId:number;
    toZoneId:number;
    createdById:string;
}

export interface OrcStockPostDto {
    stockTypeId: number;
    regionId: number;
    toZoneId: number;
    createdById: string;
    fromORCNo: number;
    toORCNo: number;
}