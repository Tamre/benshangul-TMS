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
    houseNo?: string;
    phoneNumber: string;
    secondaryPhoneNumber?: string;
    idNumber: string;
    poBox?: string;
    createdById: string;
    id: string;
    ownerId: string;
    vechicleId: string;
    vehicleRegistrationNo: string;
    fullName: string;
    amharicName: string;
    woreda: string;
    zone: string;
    trainingCenter: string;
    ownerState: string;
}

export interface OwnerPostDto {
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
    houseNo?: string;
    phoneNumber?: string;
    secondaryPhoneNumber?: string;
    idNumber?: string;
    poBox?: string;
    createdById: string;
}
 