export interface VehicleData {
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
    vehicleFileteParameter: number,
    value: string,
    regionalUser?: boolean,
    registrationType?: number
  }


  // public enum VehicleFileteParameter
  // {
  //     RegistrationNo,4
  //     PlateNo, 1
  //     ChessisNo, 3
  //     EngineNo 2
  // }