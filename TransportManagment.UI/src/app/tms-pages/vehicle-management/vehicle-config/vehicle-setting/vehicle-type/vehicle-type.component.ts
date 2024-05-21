import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { VehicleTypeService } from 'src/app/core/services/vehicle-config-services/vehicle-type.service';
import { RootReducerState } from 'src/app/store';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { VehicleTypePostDto } from 'src/app/model/vehicle-configuration/vehicle-type';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { successToast } from 'src/app/core/services/toast.service';
import { cloneDeep } from 'lodash';
import { VehicleLookupService } from 'src/app/core/services/vehicle-config-services/vehicle-lookup.service';

@Component({
  selector: 'app-vehicle-type',
  templateUrl: './vehicle-type.component.html',
  styleUrl: './vehicle-type.component.scss'
})
export class VehicleTypeComponent implements OnInit {
  submitted = false;
  isEditing: Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allVehicleTypes?: any;
  vehicleTypes?: any;

  allVehLookups?: any;
  vehLookups?: any;
  markId: number = 0;
  categoryNames: string[] = [];
  CategoryNameIdMap: { [name: string]: number } = {};

  categoryName: string[] = [];
  selectedcategoryName: { id: number; name: string } | null = null;

  successAddMessage: string = "";
  successUpdateMessage = "Vehicle Type successfully updated";
  editVehicleTypeText = "Edit Vehicle Type";
  updateText = "Update";

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
    public vehicleTypeService: VehicleTypeService,
    public vehicleLookupService: VehicleLookupService,
  ) { }
  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()
    this.getVehicleCategory()
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      id: [""],
      name: ["", [Validators.required]],
      localName: ["", [Validators.required]],
      vehicleCategoryId: ["", [Validators.required]],
      createdById: [this.currentUser?.userId, [Validators.required]],
      isActive: [true]
    });
    /**
     * fetches data
     */
    this.store.dispatch(fetchCrmContactData());
    this.store.select(selectCRMLoading).subscribe((data) => {
      if (data == false) {
        document.getElementById("elmLoader")?.classList.add("d-none");
      }
    });
  }

  getVehicleCategory() {
    this.vehicleLookupService.getAllVehicleLookup().subscribe({
      next: (res) => {
        if (res) {
          this.vehLookups = res
          this.allVehLookups = cloneDeep(res);
          this.vehLookups = this.service.changePage(this.allVehLookups)
          console.log(this.allVehLookups)
          this.categoryName = this.allVehLookups.map((veh: any) => ({
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
    this.vehicleTypes = this.service.changePage(this.allVehicleTypes);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allVehicleTypes.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.vehicleTypes = this.service.changePage(this.searchResults);
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
    this.allVehicleTypes = this.service.onSort(column, this.allVehicleTypes);
    this.vehicleTypes = this.service.changePage(this.allVehicleTypes)
  }
  refreshData() {
    this.vehicleTypeService.getAllVehicleType().subscribe({
      next: (res) => {
        if (res) {
          this.vehicleTypes = res
          this.allVehicleTypes = cloneDeep(res);
          this.vehicleTypes = this.service.changePage(this.allVehicleTypes)
          console.log(this.allVehicleTypes)
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
        const newData: VehicleTypePostDto = this.dataForm.value;
        this.vehicleTypeService.updateVehicleType(newData).subscribe({
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

        const newData: VehicleTypePostDto = this.dataForm.value;
        console.log('newData:', newData);
        this.vehicleTypeService.addVehicleType(newData).subscribe({
          next: (res: ResponseMessage) => {
            if (res.success) {
              console.log('Response:', res);
              this.successAddMessage = res.message;
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData();
            } else {
              console.error(res.message);
            }
          },
          error: (err) => {
            console.error('Error saving vehicle type:', err);
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
      this.editVehicleTypeText = res;
    });
    modelTitle.innerHTML = this.editVehicleTypeText;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText = res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.vehicleTypes[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    this.dataForm.controls["vehicleCategoryId"].setValue(this.econtent.vehicleCategoryId);

    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
