import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UntypedFormBuilder, Validators, UntypedFormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastService } from 'src/app/account/login/toast-service';
import { InspectionService } from 'src/app/core/services/Vehicle-services/inspection.service';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';
import { AddressService } from 'src/app/core/services/address.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { UserView } from 'src/app/model/user';

@Component({
  selector: 'app-technical-inspection',
  templateUrl: './technical-inspection.component.html',
  styleUrl: './technical-inspection.component.scss'
})
export class TechnicalInspectionComponent {
  technicalInspectionForm!: UntypedFormGroup;
  @Input() vehicleId!: string;
  currentUser!: UserView | null;
  vehicleBodyTypeList?: any;
  zoneList?:any;
  colorList?:any;
  submitted?:boolean;

  constructor(
    private formBuilder: UntypedFormBuilder,
    private toastService: ToastService,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public vehiclecongigService: VehicleConfigService,
    private addressService: AddressService,
    private inspectionService:InspectionService,
    
  ) {}

  refreshData() {
    this.submitted = false
    this.vehiclecongigService.getVehicleLookup(4).subscribe({
      next: (res) => {
        if (res) {
          this.colorList = res;
        }
      },
      error: (err) => {},
    });
    this.vehiclecongigService.getAllVehicleBodyType().subscribe({
      next: (res) => {
        if (res) {
          this.vehicleBodyTypeList = res;
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
    this.technicalInspectionForm = this.formBuilder.group({
      fieldInspectionId: [''],
      vehicleBodyTypeId: [null, Validators.required],
      loadMesurementId: [null, Validators.required],
      noOfPeople: [null, Validators.required],
      loadValue: [null, Validators.required],
      colorId: [null, Validators.required],
      hydroCarbon: ['', Validators.required],
      carbonMonoOxide: ['', Validators.required],
      isEngineReadable: [false, Validators.required],
      permissionLetterNo: ['', Validators.required],
      permissionDate: ['', Validators.required],
      remark: ['', Validators.required],
      createdById: ['']
    });
    this.refreshData()
  }
  submitCreateTechnicalInspection() {
    this.submitted = true;
    if (
      this.technicalInspectionForm.invalid &&
      this.vehicleId &&
      this.currentUser?.userId
    ) {
      this.toastService.show("invalid input", {
        classname: "error text-white",
        delay: 2000,
      });
    }
    this.technicalInspectionForm.controls["vehicleId"].setValue(this.vehicleId);
    this.technicalInspectionForm.controls["createdById"].setValue(
      this.currentUser?.userId
    );
  
    this.inspectionService.CreateTechnicalInspection(this.technicalInspectionForm.value).subscribe({
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
