import { Component, Input, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { VehicleService } from "src/app/core/services/vehicle.service";
import {
  IVehicleOwnerGetDto,
  OwnerGroup,
  OwnerState,
  VehicleOwnerPostDto,
} from "./IVehicleOwnersDto";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { User } from "src/app/store/Authentication/auth.models";
import { UserView } from "src/app/model/user";

@Component({
  selector: "app-vehicle-owners",
  templateUrl: "./vehicle-owners.component.html",
  styleUrl: "./vehicle-owners.component.scss",
})
export class VehicleOwnersComponent implements OnInit {
  @Input() vehicleId!: string;
  vehicleOwners: IVehicleOwnerGetDto[] = [];

  vehicleOwnerForm!: FormGroup;

  ownerStates = OwnerState;
  ownerGroups = OwnerGroup;

  userView!: UserView;

  constructor(
    private vehicleService: VehicleService,
    private fb: FormBuilder,
    private userService: TokenStorageService
  ) {}
  ngOnInit(): void {
    this.userView = this.userService.getCurrentUser()!;
    this.vehicleOwnerForm = this.fb.group({
      vehicleId: [this.vehicleId, Validators.required],
      ownerId: [null],
      trainingCenterId: [null],
      ownerState: [OwnerState.CURRENT_OWNER, Validators.required],
      ownerGroup: [OwnerGroup.Private_Owner, Validators.required],
      createdById: [this.userView.userId, Validators.required],
    });
    this.getVehicleOwnerByVehicleId();
  }

  getVehicleOwnerByVehicleId() {
    this.vehicleService.getVehicleOwnerByVehicleId(this.vehicleId).subscribe({
      next: (res) => {
        this.vehicleOwners = res;
      },
    });
  }

  onSubmit() {
    if (this.vehicleOwnerForm.valid) {
      const vehicleOwnerData: VehicleOwnerPostDto = this.vehicleOwnerForm.value;
      console.log('Form Data:', vehicleOwnerData);
      
    }
  }
}
