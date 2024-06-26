import { Component } from '@angular/core';
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
import { ServiceTypePostDto } from 'src/app/model/vehicle-configuration/service-type';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';

@Component({
  selector: 'app-service-type',
  templateUrl: './service-type.component.html',
  styleUrl: './service-type.component.scss'
})
export class ServiceTypeComponent {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allServiceTypes?:any;
  serviceTypes?: any;

  successAddMessage: string = "";
  editServiceTypeText = "Edit Service Year";
  updateText:string = "";

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

    public vehiclecongigService:VehicleConfigService
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
      isActive:[true]
    });
    /**
     * fetches data
     */

  }
  openModal(content: any) {
    this.submitted = false;
    this.isEditing = false;
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  changePage() {
    this.serviceTypes = this.service.changePage(this.allServiceTypes);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allServiceTypes.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.serviceTypes = this.service.changePage(this.searchResults);
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
    this.allServiceTypes = this.service.onSort(column, this.allServiceTypes);
    this.serviceTypes = this.service.changePage(this.allServiceTypes)
  }

  refreshData(){
    this.vehiclecongigService.getAllServiceType().subscribe({
      next: (res) => {
        if (res) 
          {
            this.serviceTypes = res
            this.allServiceTypes = cloneDeep(res);
            this.serviceTypes = this.service.changePage(this.allServiceTypes)
            console.log(this.allServiceTypes)
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
        const newData: ServiceTypePostDto = this.dataForm.value;
        this.vehiclecongigService.updateServiceType(newData).subscribe({
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
        const newData: ServiceTypePostDto = this.dataForm.value;
        newData.isActive = true;
        this.vehiclecongigService.addServiceType(newData).subscribe({
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
    this.translate.get("Edit Service Type").subscribe((res: string) => {
      this.editServiceTypeText = res;
    });
    modelTitle.innerHTML =this.editServiceTypeText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.serviceTypes[id];
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
