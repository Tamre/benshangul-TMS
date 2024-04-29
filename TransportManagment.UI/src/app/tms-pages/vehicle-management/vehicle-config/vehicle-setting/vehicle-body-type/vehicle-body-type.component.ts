import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { TranslateService } from '@ngx-translate/core';
import { RootReducerState } from 'src/app/store';
import { VehicleBodyTypeService } from 'src/app/core/services/vehicle-config-services/vehicle-body-type.service';
import { Store } from '@ngrx/store';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { cloneDeep } from 'lodash';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { successToast } from 'src/app/core/services/toast.service';
import { VehicleBodyTypePostDto } from 'src/app/model/vehicle-configuration/vehicle-body-type';
import { VehicleTypeService } from 'src/app/core/services/vehicle-config-services/vehicle-type.service';

@Component({
  selector: 'app-vehicle-body-type',
  templateUrl: './vehicle-body-type.component.html',
  styleUrl: './vehicle-body-type.component.scss'
})
export class VehicleBodyTypeComponent implements OnInit {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allVehicleBodyTypes?:any;
  vehicleBodyTypes?: any;

  allVehicleTypes?:any;
  vehicleTypes?: any;
  //markId: number = 0;
  VehicleTypeNames: string[] = [];
  VehicleTypeNameIdMap: { [name: string]: number } = {};

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
    public vehicleBodyTypeService:VehicleBodyTypeService,
    public vehicleTypeService:VehicleTypeService,
  ) {}
  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()
    this.getVehicleType()
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      id: [""],
      name: ["", [Validators.required]],
      localName: ["", [Validators.required]],
      vehicleTypeId: ["", [Validators.required]],
      value:["",[Validators.required],this.floatValidator],
      createdById: [this.currentUser?.userId, [Validators.required]],
      isActive:[true]
      //rowStatus:["",[Validators.required]],
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
  getVehicleType(){
    this.vehicleTypeService.getAllVehicleType().subscribe({
      next: (res) => {
        if (res) 
          {
            this.vehicleTypes = res
            this.allVehicleTypes = cloneDeep(res);
            this.vehicleTypes = this.service.changePage(this.allVehicleTypes)
            console.log(this.allVehicleTypes)
          // Populate the markNames array with names from vehLookups
        this.VehicleTypeNames = this.vehicleTypes.map((veh:any) => veh.name);
      }
      // Populate the markNameIdMap with name-ID mapping
      this.VehicleTypeNameIdMap = this.vehicleTypes.reduce((map:any, veh:any) => {
        map[veh.name] = veh.id;
        return map;
      }, {});
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
    this.vehicleBodyTypes = this.service.changePage(this.allVehicleBodyTypes);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allVehicleBodyTypes.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.vehicleBodyTypes = this.service.changePage(this.searchResults);
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
    this.allVehicleBodyTypes = this.service.onSort(column, this.allVehicleBodyTypes);
    this.vehicleBodyTypes = this.service.changePage(this.allVehicleBodyTypes)
  }
  refreshData(){
    this.vehicleBodyTypeService.getAllVehicleBodyType().subscribe({
      next: (res) => {
        if (res) 
          {
            this.vehicleBodyTypes = res
            this.allVehicleBodyTypes = cloneDeep(res);
            this.vehicleBodyTypes = this.service.changePage(this.allVehicleBodyTypes)
            console.log(this.allVehicleBodyTypes)
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
        const newData: VehicleBodyTypePostDto = this.dataForm.value;
        this.vehicleBodyTypeService.updateVehicleBodyType(newData).subscribe({
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
        const newData: VehicleBodyTypePostDto = this.dataForm.value;
        newData.isActive = true;
        this.vehicleBodyTypeService.addVehicleBodyType(newData).subscribe({
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
    this.translate.get("Edit Vehicle Body Type").subscribe((res: string) => {
      this.editPlateTypeText = res;
    });
    modelTitle.innerHTML =this.editPlateTypeText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.vehicleBodyTypes[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    this.dataForm.controls["vehicleTypeId"].setValue(this.econtent.vehicleTypeId);
    this.dataForm.controls["value"].setValue(
      this.econtent.value
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
