import { Component } from '@angular/core';


import { PaginationService } from 'src/app/core/services/pagination.service';
import { TranslateService } from '@ngx-translate/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';

import { cloneDeep } from 'lodash';
import { successToast } from 'src/app/core/services/toast.service';
import { ManufactureYearPostDto } from 'src/app/model/vehicle-configuration/manufacture-year';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';

@Component({
  selector: 'app-manufacture-country',
  templateUrl: './manufacture-country.component.html',
  styleUrl: './manufacture-country.component.scss'
})
export class ManufactureCountryComponent {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allManufactureCountries?:any;
  manufactureCountries?: any;

  successAddMessage : string = "";
  successUpdateMessage : string = "";
  editMnufactureCountryText = "Edit Manufacture Country ";
  updateText = "Update";

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
 
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
      listOfCountries: ["", [Validators.required]],
      value:["",[Validators.required, this.floatValidator]],
      createdById: [this.currentUser?.userId, [Validators.required]],
      isActive:[true]
    });
    

  }
  floatValidator(control: AbstractControl): ValidationErrors | null {
    if (control.value && !/^-?\d+(\.\d+)?$/.test(control.value)) {
      return { floatInvalid: true };
    }
    return null;
  }
  changePage() {
    this.manufactureCountries = this.service.changePage(this.allManufactureCountries);
  }
  refreshData(){
    this.vehicleConfigService.getAllManufactureYear().subscribe({
      next: (res) => {
        if (res) 
          {
            this.manufactureCountries = res
            this.allManufactureCountries = cloneDeep(res);
            this.manufactureCountries = this.service.changePage(this.allManufactureCountries)
            console.log(this.allManufactureCountries)
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
  // Search Data
  performSearch(): void {
    this.searchResults = this.allManufactureCountries.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.manufactureCountries = this.service.changePage(this.searchResults);
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
    this.allManufactureCountries = this.service.onSort(column, this.allManufactureCountries);
    this.manufactureCountries = this.service.changePage(this.allManufactureCountries)
  }
  //save
  saveData() {
    const updatedData = this.dataForm.value;
   
    if (this.dataForm.valid) {
      if (this.dataForm.get("id")?.value) {
        console.log(this.currentUser?.userId)
        const newData: ManufactureYearPostDto = this.dataForm.value;
        this.vehicleConfigService.updateManufactureYear(newData).subscribe({
          next: (res:ResponseMessage) => {
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
        const newData: ManufactureYearPostDto = this.dataForm.value;
        newData.isActive = true;
        this.vehicleConfigService.addManufactureYear(newData).subscribe({
          next: (res:ResponseMessage) => {
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
    this.translate.get("Edit Manufacture Country").subscribe((res: string) => {
      this.editMnufactureCountryText = res;
    });
    modelTitle.innerHTML =this.editMnufactureCountryText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.manufactureCountries[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    this.dataForm.controls["listOfCountries"].setValue(this.econtent.listOfCountries);
    this.dataForm.controls["value"].setValue(
      this.econtent.value
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
