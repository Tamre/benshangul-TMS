export interface PlateStockGetDto {
    id: string,
    plateNo: string,
    isActive: boolean,
    plateTypeId: number,
    plateTypeName:string,
    regionId: number,
    frontPlateSizeId: number,
    backPlateSizeId: number,
    plateDigit: string,
    toZoneId: number,
    givenStatus: string,
    issuanceType: string,
    isBackLog: boolean,
    createdById: string,
    aToZ: string
}

export interface PlateStockPostDto {
    plateTypeId: number;
    regionId: number;
    frontPlateSizeId: number;
    backPlateSizeId?: number;
    plateDigit: string;
    toZoneId?: number;
    givenStatus: string;
    issuanceType: string;
    isBackLog: boolean;
    createdById: string;
    aToZ?: string;
    fromPlateNo: number;
    toPlateNo: number
}