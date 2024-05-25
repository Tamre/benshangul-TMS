export interface OwnerGetDto {
    firstName: string;
    middleName: string;
    lastName: string;
    amharicFirstName: string;
    amharicMiddleName: string;
    amharicLastName: string;
    gender: string;
    zoneId: number;
    woredaId?: string;
    town?: string;
    houseNo: string;
    phoneNumber: string;
    secondaryPhoneNumber?: string;
    idNumber: string;
    poBox?: string;
    createdById: string;
    ownerGroup: string;
    id: string;
    ownerNumber: string;
    //vechicleId: string;
    //vehicleRegistrationNo: string;
    fullName: string;
    amharicName: string;
    woreda: string;
    zone: string;
    serviceZoneId: string;
    //trainingCenter: string;
    //ownerState: string;
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
export interface OwnerPostDto {
    ownerGroup: number;
    firstName: string;
    middleName: string;
    lastName: string;
    amharicFirstName: string;
    amharicMiddleName: string;
    amharicLastName: string;
    gender: number;
    zoneId: number;
    woredaId?: string;
    town?: string;
    houseNo: string;
    phoneNumber: string;
    secondaryPhoneNumber?: string;
    idNumber: string;
    poBox?: string;
    createdById: string;
    serviceZoneId: number;
}