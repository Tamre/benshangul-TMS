export interface CreateFieldInspectionDto {
    vehicleId: string;
    givenZoneId: number;
    serviceChangeId: string;
    width: number;
    height: number;
    length: number;
    frontTyreSize: string;
    rearTyreSize: string;
    noOfRearAxel: number;
    noOfFrontAxel: number;
    axelDriveType: string;
    numberOfTyre: number;
    frontAxelMaxLoad: number;
    rearAxelMaxLoad: number;
    grossWeight: number;
    tareWeight: number;
    frontPlateSizeId: number;
    backPlateSizeId: number;
    createdById: string;
  }
  