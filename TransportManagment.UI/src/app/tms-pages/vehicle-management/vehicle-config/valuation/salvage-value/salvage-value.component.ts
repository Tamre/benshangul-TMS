import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalvageValueService } from 'src/app/core/services/vehicle-config-services/salvage-value.service';
import { UntypedFormGroup, UntypedFormBuilder, AbstractControl, ValidationErrors, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { UserView } from 'src/app/model/user';
import { RootReducerState } from 'src/app/store';
import { cloneDeep } from 'lodash';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { successToast } from 'src/app/core/services/toast.service';
import { SalvageValuePostDto } from 'src/app/model/vehicle-configuration/salvage-value';

@Component({
  selector: 'app-salvage-value',
  templateUrl: './salvage-value.component.html',
  styleUrl: './salvage-value.component.scss'
})
export class SalvageValueComponent {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allSalvageValue?:any;
  salvageValue?: any;

  successAddMessage : string= "";
  editSalvageValueText = "Edit Salvage Value";
  updateText = "Update";

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
    public salvageValueService:SalvageValueService
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
  floatValidator(control: AbstractControl): ValidationErrors | null {
    if (control.value && !/^-?\d+(\.\d+)?$/.test(control.value)) {
      return { floatInvalid: true };
    }
    return null;
  }
  changePage() {
    this.salvageValue = this.service.changePage(this.allSalvageValue);
  }
  refreshData(){
    this.salvageValueService.getAllSalvageValue().subscribe({
      next: (res) => {
        if (res) 
          {
            this.salvageValue = res
            this.allSalvageValue = cloneDeep(res);
            this.salvageValue = this.service.changePage(this.allSalvageValue)
            console.log(this.allSalvageValue)
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
    this.searchResults = this.allSalvageValue.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.salvageValue = this.service.changePage(this.searchResults);
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
    this.allSalvageValue = this.service.onSort(column, this.allSalvageValue);
    this.salvageValue = this.service.changePage(this.allSalvageValue)
  }
  //save
  saveData() {
    const updatedData = this.dataForm.value;
   
    if (this.dataForm.valid) {
      if (this.dataForm.get("id")?.value) {
        console.log(this.currentUser?.userId)
        const newData: SalvageValuePostDto = this.dataForm.value;
        this.salvageValueService.updateSalvageValue(newData).subscribe({
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
        const newData: SalvageValuePostDto = this.dataForm.value;
        this.salvageValueService.addSalvageValue(newData).subscribe({
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
    this.translate.get("Edit Salvage Value").subscribe((res: string) => {
      this.editSalvageValueText = res;
    });
    modelTitle.innerHTML =this.editSalvageValueText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.salvageValue[id];
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
