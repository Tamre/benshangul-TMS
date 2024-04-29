import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ManufactureCountryService } from 'src/app/core/services/vehicle-config-services/manufacture-country.service';
import { RootReducerState } from 'src/app/store';
import { Store } from '@ngrx/store';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { TranslateService } from '@ngx-translate/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { cloneDeep } from 'lodash';
import { successToast } from 'src/app/core/services/toast.service';
import { ManufactureYearPostDto } from 'src/app/model/vehicle-configuration/manufacture-year';

@Component({
  selector: 'app-manufacture-year',
  templateUrl: './manufacture-year.component.html',
  styleUrl: './manufacture-year.component.scss'
})
export class ManufactureYearComponent {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allManufactureCountries?:any;
  manufactureCountries?: any;

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
    private store: Store<{ data: RootReducerState }>,
    public manufactureCountryService:ManufactureCountryService
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
    this.manufactureCountries = this.service.changePage(this.allManufactureCountries);
  }
  refreshData(){
    this.manufactureCountryService.getAllManufactureYear().subscribe({
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
        this.manufactureCountryService.updateManufactureYear(newData).subscribe({
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
        const newData: ManufactureYearPostDto = this.dataForm.value;
        // const newData: Omit<StockTypePostDto, 'id'> = {
        //   ...this.dataForm.value,
        // };
        newData.isActive = true;
        this.manufactureCountryService.addManufactureYear(newData).subscribe({
          next: (res) => {
            if (res.success) {
              this.translate.get('Manufacture Year sucessfully added').subscribe((res: string) => {
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
