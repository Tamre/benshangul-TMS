import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';


import { TranslateService } from '@ngx-translate/core';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

import { cloneDeep } from 'lodash';
import { successToast } from 'src/app/core/services/toast.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { VehicleModelPostDto } from 'src/app/model/vehicle-configuration/vehicle-model';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';

@Component({
  selector: 'app-vehicle-model',
  templateUrl: './vehicle-model.component.html',
  styleUrl: './vehicle-model.component.scss'
})
export class VehicleModelComponent implements OnInit {
  submitted = false;
  isEditing: Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allVehicleModels?: any;
  vehicleModels?: any;

  allVehLookups?: any;
  vehLookups?: any;
  markId: number = 0;
  markNames: string[] = [];
  markNameIdMap: { [name: string]: number } = {};
  selectedMark: { id: number; name: string } | null = null;

  markName: string[] = [];
  selectedMarkName: { id: number; name: string } | null = null;

  horsePowerMeasureDropDownItem = [
    { name: 'Brake Horsepower(BPH)', code: 'BHP' },
    { name: 'Kilowatt(KW)', code: 'KW' }
  ]


  successAddMessage: string = "";
  successUpdateMessage = "Vehicle Type successfully updated";
  editPlateTypeText = "Edit Vehicle Type";
  updateText = "Update";

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,

    public vehicleConfigService: VehicleConfigService
  ) { }
  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()
    this.getMark()
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      id: [""],
      name: ["", [Validators.required]],
      engineCapacity: ["", [Validators.required, Validators.pattern(/^-?\d+$/)]],
      noOfCylinder: ["", [Validators.required, Validators.pattern(/^-?\d+$/)]],
      horsePowerMeasure: ["", [Validators.required]],
      markId: ["", [Validators.required]],
      createdById: [this.currentUser?.userId, [Validators.required]],
      isActive: [true]
    });

  }
  gethorsePowerMeasureName(code: string): string {
    const horsePowerMeasure = this.horsePowerMeasureDropDownItem.find(item => item.code === code);
    return horsePowerMeasure ? horsePowerMeasure.name : code;
  }

  getMark() {
    this.vehicleConfigService.getVehicleLookup(this.markId).subscribe({
      next: (res) => {
        if (res) {
          this.vehLookups = res
          this.allVehLookups = cloneDeep(res);
          this.vehLookups = this.service.changePage(this.allVehLookups)
          console.log(this.allVehLookups)

          this.markName = this.allVehLookups.map((veh: any) => ({
            id: veh.id,
            name: veh.name,
          }));
        }

      },
      error: (err) => {

      },
    });
  }
  openModal(content: any) {
    this.submitted = false;
    this.isEditing = false;
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  changePage() {
    this.vehicleModels = this.service.changePage(this.allVehicleModels);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allVehicleModels.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.vehicleModels = this.service.changePage(this.searchResults);
  }
  // Sort filter
  sortField: any;
  sortBy: any;
  SortFilter() {
    this.sortField = (
      document.getElementById("choices-single-default") as HTMLInputElement
    ).value;
    if (this.sortField[0] == "A") {
      this.sortBy = "desc";
      this.sortField = this.sortField.replace(/A/g, "");
    }
    if (this.sortField[0] == "D") {
      this.sortBy = "asc";
      this.sortField = this.sortField.replace(/D/g, "");
    }
  }
  // Sort data
  onSort(column: any) {
    this.allVehicleModels = this.service.onSort(column, this.allVehicleModels);
    this.vehicleModels = this.service.changePage(this.allVehicleModels)
  }
  refreshData() {
    this.vehicleConfigService.getAllVehicleModel().subscribe({
      next: (res) => {
        if (res) {
          this.vehicleModels = res
          this.allVehicleModels = cloneDeep(res);
          this.vehicleModels = this.service.changePage(this.allVehicleModels)
          console.log(this.allVehicleModels)

        }
      },
      error: (err) => {

      },
    });
  }

  saveData() {
    const updatedData = this.dataForm.value;

    if (this.dataForm.valid) {
      if (this.dataForm.get("id")?.value) {
        console.log(this.currentUser?.userId)
        const newData: VehicleModelPostDto = this.dataForm.value;
        this.vehicleConfigService.updateVehicleModel(newData).subscribe({
          next: (res: ResponseMessage) => {
            if (res.success) {
              this.successAddMessage = res.message;
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData();
            } else {
              console.error(res.message);
            }
          },
          error: (err) => {
            console.error(err);
          },
        });

      } else {

        const newData: VehicleModelPostDto = this.dataForm.value;
        newData.isActive = true;
        this.vehicleConfigService.addVehicleModel(newData).subscribe({
          next: (res: ResponseMessage) => {
            if (res.success) {
              this.successAddMessage = res.message;
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData();
            } else {
              console.error(res.message);
            }
          },
          error: (err) => {
            console.error(err);
          },
        });
      }
    }
    this.submitted = true;
  }

  closeModal() {
    this.modalService.dismissAll();
  }
  /**
   * Form data get
   */
  get form() {
    return this.dataForm.controls;
  }
  editDataGet(id: any, content: any) {
    this.submitted = false;
    this.modalService.open(content, { size: "lg", centered: true });
    var modelTitle = document.querySelector(".modal-title") as HTMLAreaElement;
    this.translate.get("Edit Vehicle Type").subscribe((res: string) => {
      this.editPlateTypeText = res;
    });
    modelTitle.innerHTML = this.editPlateTypeText;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText = res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.vehicleModels[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["engineCapacity"].setValue(this.econtent.engineCapacity);
    this.dataForm.controls["noOfCylinder"].setValue(this.econtent.noOfCylinder);
    this.dataForm.controls["horsePowerMeasure"].setValue(
      this.econtent.horsePowerMeasure
    );
    this.dataForm.controls["markId"].setValue(
      this.econtent.markId
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
