import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { StockTypePostDto } from 'src/app/model/vehicle-configuration/stock-type';
import { StockTypeService } from 'src/app/core/services/vehicle-config-services/stock-type.service';
import { TranslateService } from '@ngx-translate/core';
import { successToast } from "src/app/core/services/toast.service";
import { cloneDeep } from 'lodash';
import { Store } from '@ngrx/store';
import { RootReducerState } from 'src/app/store';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';

@Component({
  selector: 'app-stock-type',
  //standalone: true,
  //imports: [CommonModule],
  templateUrl: './stock-type.component.html',
  styleUrl: './stock-type.component.scss'
})
export class StockTypeComponent {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  allStocks?:any;
  stocks?: any;
  econtent?: any;

  successAddMessage = "AISORC Stock Type successfully added";
  successUpdateMessage = "AISORC Stock Type successfully updated";
  editCountryText = "Edit AISORC Stock Type";
  updateText = "Update";

  CategoryDropDownItem = [
    { name: 'AIS', code: 'AIS'},
    { name: 'ORC', code: 'ORC'}
  ]

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public stockTypeService: StockTypeService,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
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
      code: ["", [Validators.required]],
      category:["",[Validators.required]],
      createdById: [this.currentUser?.id, [Validators.required]],
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


  openModal(content: any) {
    this.submitted = false;
    this.isEditing = false;
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.id);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  changePage() {
    this.stocks = this.service.changePage(this.allStocks);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allStocks.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.stocks = this.service.changePage(this.searchResults);
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
    this.allStocks = this.service.onSort(column, this.allStocks);
    this.stocks = this.service.changePage(this.allStocks)
  }

  refreshData(){
    this.stockTypeService.getAllStockType().subscribe({
      next: (res) => {
        if (res) 
          {
            this.stocks = res
            this.allStocks = cloneDeep(res);
            this.stocks = this.service.changePage(this.allStocks)
            console.log(this.allStocks)
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
        console.log(this.currentUser?.id)
        const newData: StockTypePostDto = this.dataForm.value;
        this.stockTypeService.updateStockType(newData).subscribe({
          next: (res) => {
            if (res.success) {
              this.translate.get('AISORC Stock Type sucessfully updated').subscribe((res: string) => {
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
        const newData: StockTypePostDto = this.dataForm.value;
        // const newData: Omit<StockTypePostDto, 'id'> = {
        //   ...this.dataForm.value,
        // };
        newData.isActive = true;
        this.stockTypeService.addStockType(newData).subscribe({
          next: (res) => {
            if (res.success) {
              this.translate.get('country sucessfully added').subscribe((res: string) => {
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
    // setTimeout(() => {
    //   this.dataForm.reset();
    // }, 2000);
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
    this.translate.get("Edit Stock Type").subscribe((res: string) => {
      this.editCountryText = res;
    });
    modelTitle.innerHTML =this.editCountryText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.stocks[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    this.dataForm.controls["code"].setValue(this.econtent.code);
    this.dataForm.controls["category"].setValue(
      this.econtent.category
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.id);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
