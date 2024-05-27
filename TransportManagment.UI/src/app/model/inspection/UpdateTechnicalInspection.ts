export interface UpdateTechnicalInspectionDto {
    fieldInspectionId: string;
    vehicleBodyTypeId: number;
    serviceTypeId: number;
    loadMesurementId: number;
    noOfPeople: number;
    loadValue: number;
    colorId: number;
    hydroCarbon: string;
    carbonMonoOxide: string;
    isEngineReadable: boolean;
    permissionLetterNo: string;
    permissionDate: string; // You may want to use Date type if you are handling dates in your application
    remark: string;
    createdById: string;
    id: string;
    vehicleBodyTypeName: string;
    serviceType: string;
    loadMeasurment: string;
    color: string;
  }
  