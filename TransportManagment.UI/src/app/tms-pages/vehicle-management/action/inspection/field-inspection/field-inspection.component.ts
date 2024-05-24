import { Component, Input, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from "@angular/forms";
import { errorToast } from "src/app/core/services/toast.service";
import { ToastService } from "src/app/account/login/toast-service";
import { UserView } from "src/app/model/user";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { VehicleConfigService } from "src/app/core/services/Vehicle-services/vehicle-config.service";
import { AddressService } from "src/app/core/services/address.service";
import { InspectionService } from "src/app/core/services/Vehicle-services/inspection.service";

@Component({
  selector: "app-field-inspection",
  templateUrl: "./field-inspection.component.html",
  styleUrl: "./field-inspection.component.scss",
})
export class FieldInspectionComponent implements OnInit {
  fieldInspectionForm!: UntypedFormGroup;
  @Input() vehicleId!: string;
  currentUser!: UserView | null;
  plateSizeList?: any;
  zoneList?:any;
  submitted?:boolean;

  constructor(
    private formBuilder: UntypedFormBuilder,
    private toastService: ToastService,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public vehiclecongigService: VehicleConfigService,
    private addressService: AddressService,
    private inspectionService:InspectionService
  ) {}

  refreshData() {
    this.submitted = false
    this.vehiclecongigService.getVehicleLookup(2).subscribe({
      next: (res) => {
        if (res) {
          this.plateSizeList = res;
        }
      },
      error: (err) => {},
    });
    this.addressService.getAllZone().subscribe({
      next: (res) => {
        if (res) {
          this.zoneList = res;
        }
      },
      error: (err) => {},
    });
    
  }

  ngOnInit(): void {

    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.fieldInspectionForm = this.formBuilder.group({
      vehicleId: [""],
      givenZoneId: [null, Validators.required],
      width: [null, Validators.required],
      height: [null, Validators.required],
      length: [null, Validators.required],
      frontTyreSize: ["", Validators.required],
      rearTyreSize: ["", Validators.required],
      noOfRearAxel: [null, Validators.required],
      noOfFrontAxel: [null, Validators.required],
      axelDriveType: ["", Validators.required],
      numberOfTyre: [null, Validators.required],
      frontAxelMaxLoad: [null, Validators.required],
      rearAxelMaxLoad: [null, Validators.required],
      grossWeight: [null, Validators.required],
      tareWeight: [null, Validators.required],
      frontPlateSizeId: [null, Validators.required],
      backPlateSizeId: [null, Validators.required],
      createdById: [""],
    });
    this.refreshData()
  }
  submitCreateFieldInspection() {
    this.submitted = true;
    if (
      this.fieldInspectionForm.invalid &&
      this.vehicleId &&
      this.currentUser?.userId
    ) {
      this.toastService.show("invalid input", {
        classname: "error text-white",
        delay: 2000,
      });
    }
    this.fieldInspectionForm.controls["vehicleId"].setValue(this.vehicleId);
    this.fieldInspectionForm.controls["createdById"].setValue(
      this.currentUser?.userId
    );
  
    this.inspectionService.createFieldInspection(this.fieldInspectionForm.value).subscribe({
      next: (res) => {
        this.toastService.show(res.message, {
          classname: "success text-white",
          delay: 2000,
        });
        this.submitted = true;
      },
      error: (err) => {
        this.toastService.show("unable to add inspection", {
          classname: "error text-white",
          delay: 2000,
        });
      },
    });
  }
  openModal(content: any) {
    this.modalService.open(content, { size: "lg", centered: true });
  }
}
