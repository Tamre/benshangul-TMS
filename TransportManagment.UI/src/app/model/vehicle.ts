export interface VehicleData {
    id?:string;
    registrationNumber?:string
    modelId: number;
    taxStatus: string;
    officeCode: string;
    declarationNo: string;
    declarationDate: Date;
    billOfLoading: string;
    removalNumber: string;
    invoiceDate: Date;
    invoicePrice: number;
    chassisNo: string;
    engineNumber: string;
    assembledCountryId: number;
    chassisMadeId: number;
    manufacturingYear: number;
    horsePower: number;
    horsePowerMeasure: string;
    noCylinder: number;
    engineCapacity: number;
    lastActionTaken: string;
    typeOfVehicle: string;
    vehicleCurrentStatus: string;
    transferStatus: string;
    serviceZoneId: number;
    createdById: string;

  }
  


  export interface GetVehicleDetailRequestDto{
    vehicleFileteParameter: string,
    value: string,
    regionalUser?: boolean,
    registrationType?: string
  }


  // public enum VehicleFileteParameter
  // {
  //     RegistrationNo,4
  //     PlateNo, 1
  //     ChessisNo, 3
  //     EngineNo 2
  // }


export interface VehicleDetailDto
{
    id: string;
    registrationNumber: string;
    registrationType: string;
    model:string;
    mdelId: string;
    taxStatus: string;
    officeCode: string;
    declarationNo: string;
    declarationDate: Date;
    billOfLoading: string;
    removalNumber: string;
    invoiceDate: Date;
    invoicePrice: number;
    chassisNo: string;
    engineNumber: string;
    assembledCountryId: number;
    assembledCountry: string;
    chassisMadeId: number;
    chassisMadeCountry: string;
    manufacturingYear: number;
    horsePower: number;
    approvalStatus: string;
    horsePowerMeasure: string;
    noCylinder: number;
    engineCapacity: number;
    typeOfVehicle: string;
    vehicleCurrentStatus: string;
    transferStatus: string;
    serviceZone: string;

    plateNumber?:string
}