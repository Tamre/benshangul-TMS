export interface IVehicleOwnerGetDto {
  id: string; // Assuming Id is a GUID, use string
  vehicleId: string; // Assuming VehicleId is a GUID, use string
  ownerId: string; // Assuming OwnerId is a GUID, use string
  ownerNumber:string,
  fullName: string;
  amharicName: string;
  vehicleRegistrationNo: string;
  zone: string;
  woreda: string;
  gender: string;
  idNumber: string;
  town: string;
  houseNo: string;
  phoneNumber: string;
  secondaryPhoneNumber: string;
  poBox: string;
  trainingCenter: string;
  ownerState: string;
}

export interface VehicleOwnerPostDto {
  vehicleId: string;
  ownerId?: string;
  trainingCenterId?: string;
  ownerState: OwnerState;
  ownerGroup: OwnerGroup;
  createdById: string;
}

// Define the enum types based on your C# enums
export enum OwnerState {
  CURRENT_OWNER,
  FORMER_OWNER,
  DELETED_OWNER,
}

export enum OwnerGroup {
    Private_Owner,
    Organization,
    Government
}

export interface IOwnerListDropdownDto
{
    id :string
    ownerName : string
    ownerNumber : string
    ownerGroup : OwnerGroup

}

