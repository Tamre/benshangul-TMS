import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';


import { TranslateService } from '@ngx-translate/core';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

import { cloneDeep } from 'lodash';
import { successToast } from 'src/app/core/services/toast.service';
import { DepCostPostDto } from 'src/app/model/vehicle-configuration/dep-cost';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';

@Component({
  selector: 'app-depreciatio-cost',
  templateUrl: './depreciatio-cost.component.html',
  styleUrl: './depreciatio-cost.component.scss'
})
export class DepreciatioCostComponent {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allDepCost?:any;
  depCost?: any;

  successAddMessage = "Depreciation Cost successfully added";
  successUpdateMessage = "Depreciation Cost successfully updated";
  editDepCostText = "Edit Depreciation Cost";
  updateText = "Update";

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
      //code: ["", [Validators.required]],
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
    this.depCost = this.service.changePage(this.allDepCost);
  }
  refreshData(){
    this.vehiclecongigService.getAllDepCost().subscribe({
      next: (res) => {
        if (res) 
          {
            this.depCost = res
            this.allDepCost = cloneDeep(res);
            this.depCost = this.service.changePage(this.allDepCost)
            console.log(this.allDepCost)
          }
      },
      error: (err) => {
        err
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
    this.searchResults = this.allDepCost.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.depCost = this.service.changePage(this.searchResults);
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
    this.allDepCost = this.service.onSort(column, this.allDepCost);
    this.depCost = this.service.changePage(this.allDepCost)
  }
  //save
  saveData() {
    const updatedData = this.dataForm.value;
   
    if (this.dataForm.valid) {
      if (this.dataForm.get("id")?.value) {
        console.log(this.currentUser?.userId)
        const newData: DepCostPostDto = this.dataForm.value;
        this.vehiclecongigService.updateDepCost(newData).subscribe({
          next: (res) => {
            if (res.success) {
              this.translate.get('Depreciation Cost sucessfully updated').subscribe((res: string) => {
                this.successAddMessage = res;
              });
              this.closeModal();
              successToast(this.successUpdateMessage);
              this.refreshData()
            }
          },
          error: (err) => {},
        });

      } else {
        const newData: DepCostPostDto = this.dataForm.value;
        newData.isActive = true;
        this.vehiclecongigService.addDepCost(newData).subscribe({
          next: (res) => {
            if (res.success) {
              this.translate.get('Depreciation Cost sucessfully added').subscribe((res: string) => {
                this.successAddMessage = res;
              });
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
    this.translate.get("Edit Depreciation Cost").subscribe((res: string) => {
      this.editDepCostText = res;
    });
    modelTitle.innerHTML =this.editDepCostText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.depCost[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    //this.dataForm.controls["code"].setValue(this.econtent.code);
    this.dataForm.controls["value"].setValue(
      this.econtent.value
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
