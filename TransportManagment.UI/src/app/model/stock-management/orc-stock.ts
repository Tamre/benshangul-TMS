export interface OrcStockGetDto {
    id:string;
    orcNo:number;
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
export interface OrcStockPostDto {
    stockTypeId: number;
    regionId: number;
    toZoneId: number;
    createdById: string;
    fromORCNo: number;
    toORCNo: number;
}