import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UntypedFormGroup, UntypedFormBuilder, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { UserView } from 'src/app/model/user';
import { RootReducerState } from 'src/app/store';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { cloneDeep } from 'lodash';
import { ServiceYearPostDto } from 'src/app/model/vehicle-configuration/service-year';
import { successToast } from 'src/app/core/services/toast.service';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';

@Component({
  selector: 'app-service-year',
  templateUrl: './service-year.component.html',
  styleUrl: './service-year.component.scss'
})
export class ServiceYearComponent {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allServiceYears?:any;
  serviceYears?: any;

  successAddMessage: string = "";
  editPlateTypeText = "Edit Service Year";
  updateText = "Update";

  serviceModuleDropDownItem = [
    { name: 'DPMS', code: 'DPMS'},
    { name: 'VRMS', code: 'VRMS'},
    { name: 'PUBLIC', code: 'PUBLIC'},
    { name: 'FRIGHT', code: 'FRIGHT'}
  ]

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
    public vehicleConfigService:VehicleConfigService
  ) {}
  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      id: [""],
      name: ["", [Validators.required]],
      localName: ["", [Validators.required]],
      serviceModule: ["", [Validators.required]],
      listOfPlates:["",[Validators.required]],
      listOfAIS:["",[Validators.required]],
      createdById: [this.currentUser?.userId, [Validators.required]],
      //isActive:[true]
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
  openModal(content: any) {
    this.submitted = false;
    this.isEditing = false;
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  changePage() {
    this.serviceYears = this.service.changePage(this.allServiceYears);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allServiceYears.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.serviceYears = this.service.changePage(this.searchResults);
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
    this.allServiceYears = this.service.onSort(column, this.allServiceYears);
    this.serviceYears = this.service.changePage(this.allServiceYears)
  }

  refreshData(){
    this.vehicleConfigService.getAllServiceYear().subscribe({
      next: (res) => {
        if (res) 
          {
            this.serviceYears = res
            this.allServiceYears = cloneDeep(res);
            this.serviceYears = this.service.changePage(this.allServiceYears)
            console.log(this.allServiceYears)
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
        const newData: ServiceYearPostDto = this.dataForm.value;
        this.vehicleConfigService.updateServiceYear(newData).subscribe({
          next: (res) => {
            if (res.success) {
              this.successAddMessage = res.message;
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData()
            }
          },
          error: (err) => {},
        });

      } else {
        const newData: ServiceYearPostDto = this.dataForm.value;
        //newData.isActive = true;
        this.vehicleConfigService.addServiceYear(newData).subscribe({
          next: (res) => {
            if (res.success) {
              this.successAddMessage = res.message;
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData()
            }
          },
          error: (err) => {},
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
    this.translate.get("Edit Service Year").subscribe((res: string) => {
      this.editPlateTypeText = res;
    });
    modelTitle.innerHTML =this.editPlateTypeText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.serviceYears[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    this.dataForm.controls["serviceModule"].setValue(this.econtent.serviceModule);
    this.dataForm.controls["listOfPlates"].setValue(
      this.econtent.listOfPlates
    );
    this.dataForm.controls["listOfAIS"].setValue(
      this.econtent.listOfAIS
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
