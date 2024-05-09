export interface AisStockGetDto {
    id:string;
    aisNo:number;
    isActive:boolean;
    stockTypeId:number;
    regionId:number;
    toZoneId:number;
    createdById:string;
}
export interface PaginatedResponse<T> {
    data: T[];
    metaData: MetaData;
}

export interface MetaData {
    currentPage: number;
    totalPages: number;
    pageSize: number;
    totalCount: number;
    hasPrevious: boolean;
    hasNext: boolean;
}
export interface AisStockPostDto {
    stockTypeId: number;
    regionId: number;
    toZoneId: number;
    createdById: string;
    fromAISNo: number;
    toAISNo: number;

}