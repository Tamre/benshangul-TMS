import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InitialPriceService } from 'src/app/core/services/vehicle-config-services/initial-price.service';
import { UntypedFormGroup, UntypedFormBuilder, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
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
import { successToast } from 'src/app/core/services/toast.service';
import { InitialPricePostDto } from 'src/app/model/vehicle-configuration/initial-price';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Component({
  selector: 'app-initial-price',
  templateUrl: './initial-price.component.html',
  styleUrl: './initial-price.component.scss'
})
export class InitialPriceComponent {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allInitialPrice?:any;
  initialPrice?: any;

  successAddMessage: string = "";
  editServiceYearText = "Edit Service Year";
  updateText = "Update";

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
    public initialPriceService:InitialPriceService
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
      price: ["", [Validators.required],this.floatValidator],
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
    this.initialPrice = this.service.changePage(this.allInitialPrice);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allInitialPrice.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.initialPrice = this.service.changePage(this.searchResults);
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
    this.allInitialPrice = this.service.onSort(column, this.allInitialPrice);
    this.initialPrice = this.service.changePage(this.allInitialPrice)
  }
  refreshData(){
    this.initialPriceService.getAllInitialPrice().subscribe({
      next: (res) => {
        if (res) 
          {
            this.initialPrice = res
            this.allInitialPrice = cloneDeep(res);
            this.initialPrice = this.service.changePage(this.allInitialPrice)
            console.log(this.allInitialPrice)
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
        const newData: InitialPricePostDto = this.dataForm.value;
        this.initialPriceService.updateInitialPrice(newData).subscribe({
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
        const newData: InitialPricePostDto = this.dataForm.value;
        //newData.isActive = true;
        this.initialPriceService.addInitialPrice(newData).subscribe({
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
    this.translate.get("Edit Initial Price").subscribe((res: string) => {
      this.editServiceYearText = res;
    });
    modelTitle.innerHTML =this.editServiceYearText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.initialPrice[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    this.dataForm.controls["price"].setValue(this.econtent.price);

    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
