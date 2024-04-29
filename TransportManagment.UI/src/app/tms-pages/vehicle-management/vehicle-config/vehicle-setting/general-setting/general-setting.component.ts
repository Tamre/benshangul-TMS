import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { VehicleSettingService } from 'src/app/core/services/vehicle-config-services/vehicle-setting.service';
import { RootReducerState } from 'src/app/store';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { cloneDeep } from 'lodash';
import { VehicleSettingPostDto } from 'src/app/model/vehicle-configuration/vehicle-setting';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { successToast } from 'src/app/core/services/toast.service';

@Component({
  selector: 'app-general-setting',
  templateUrl: './general-setting.component.html',
  styleUrl: './general-setting.component.scss'
})
export class GeneralSettingComponent implements OnInit{
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allVehicleSettings?:any;
  vehicleSettings?: any;

  vehicleSettingTypeDropDownItem= [
    { name: 'ANNUAL_INSPECTION_EXPIRE_YEAR', code: '0'},
    { name: 'ANNUAL_iNSPECTION_MONTH_sTART', code: '1'},
    { name: 'ANNUAL_iNSPECTION_MONTH_END', code: '2'},
    { name: 'ET_INSPECTION_MONTH_START', code: '3'},
    { name: 'EN_INSPECTION_MONTH_END', code: '4'},
    { name: 'TEMPORARY_PLATE_EXPIREDATE', code: '5'},
    { name: 'TEMPORARY_PLATE_EXTENDDATE', code: '6'},
    { name: 'ORGANIZATION_DAYS_PER_VEHICLE', code: '7'},
    { name: 'ORGANIZATION_NEW_LICENSE_YEARS', code: '8'},
    { name: 'ORGANIZATION_RENEW_LICENSEYEARS', code: '9'},
    { name: 'NUMBER_OF_INSPECTORS', code: '10'}
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
    private store: Store<{ data: RootReducerState }>,
    public vehicleSettingService:VehicleSettingService
  ) {}
  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      id: [""],
      vehicleSettingType: ["", [Validators.required]],
      value: ["", [Validators.required],this.floatValidator],
      createdById: [this.currentUser?.userId, [Validators.required]],
      isActive:[true]
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
  floatValidator(control: AbstractControl): Promise<ValidationErrors | null> {
    return Promise.resolve().then(() => {
       if (control.value && !/^-?\d+(\.\d+)?$/.test(control.value)) {
         return { floatInvalid: true };
       }
       return null;
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
    this.vehicleSettings = this.service.changePage(this.allVehicleSettings);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allVehicleSettings.filter((item: any) => {
      return item.vehicleSettingType.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.vehicleSettings = this.service.changePage(this.searchResults);
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
    this.allVehicleSettings = this.service.onSort(column, this.allVehicleSettings);
    this.vehicleSettings = this.service.changePage(this.allVehicleSettings)
  }
  refreshData(){
    this.vehicleSettingService.getAllVehicleSetting().subscribe({
      next: (res) => {
        if (res) 
          {
            this.vehicleSettings = res
            this.allVehicleSettings = cloneDeep(res);
            this.vehicleSettings = this.service.changePage(this.allVehicleSettings)
            console.log(this.allVehicleSettings)
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
        const newData: VehicleSettingPostDto = this.dataForm.value;
        this.vehicleSettingService.updateVehicleSetting(newData).subscribe({
          next: (res: ResponseMessage) => {
            if (res.success) {
              this.successAddMessage = res.message;
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData();
            } else {
              console.error( res.message);
            }
          },
          error: (err) => {
            console.error(err);
          },
        });

      } else {
        const newData: VehicleSettingPostDto = this.dataForm.value;
        newData.isActive = true;
        this.vehicleSettingService.addVehicleSetting(newData).subscribe({
          next: (res: ResponseMessage) => {
            if (res.success) {
              this.successAddMessage = res.message;
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData();
            } else {
              console.error( res.message);
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
    modelTitle.innerHTML =this.editPlateTypeText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.vehicleSettings[id];
    this.dataForm.controls["vehicleSettingType"].setValue(this.econtent.vehicleSettingType);
    this.dataForm.controls["value"].setValue(this.econtent.value);

    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
