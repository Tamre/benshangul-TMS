export interface UpdateFieldInspectionDto {
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
  frontAxelMAxLoad: number;
  rearAxelMaxLoad: number;
  grossWeight: number;
  tareWeight: number;
  frontPlateSizeId: number;
  backPlateSizeId: number;
  createdById: string;
  givenZoneName: string;
  id: string;
  frontPlateSize: string;
  backPlateSize: string;
}
