export interface CreateTechnicalInspectionDto {
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
        permissionDate: string; // or Date if you plan to use Date objects
        remark: string;
        createdById: string;
}