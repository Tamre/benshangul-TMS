import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { StockTypePostDto } from 'src/app/model/vehicle-configuration/stock-type';
import { TranslateService } from '@ngx-translate/core';
import { successToast } from "src/app/core/services/toast.service";
import { cloneDeep } from 'lodash';


import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';

@Component({
  selector: 'app-aisorc-stock-type',
  templateUrl: './aisorc-stock-type.component.html',
  styleUrl: './aisorc-stock-type.component.scss'
})
export class AisorcStockTypeComponent {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  allStocks?:any;
  stocks?: any;
  econtent?: any;

  successAddMessage: string = "";
  editStockTypeText = "Edit AISORC Stock Type";
  updateText = "Update";

  CategoryDropDownItem = [
    { name: 'Annual Inspection Statement ("Bolo")', code: 'AIS'},
    { name: 'Ownership Registration Certificate(“Libre”)', code: 'ORC'}
  ]

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public vehiclecongigService: VehicleConfigService,
    public translate: TranslateService,
  
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
      code: ["", [Validators.required, Validators.maxLength(3)]],
      category:["",[Validators.required]],
      createdById: [this.currentUser?.userId, [Validators.required]],
      isActive:[true]
      //,Validators.pattern(/^-?\d+$/)
    });
   

  }
  getCategoryName(code: string): string {
    const category = this.CategoryDropDownItem.find(item => item.code === code);
    return category ? category.name : code;
  }
  numValidator(control: AbstractControl): Promise<ValidationErrors | null> {
    return Promise.resolve().then(() => {
       if (!Number.isInteger(control.value)) {
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
    this.vehiclecongigService.getAllStockType().subscribe({
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
        console.log(this.currentUser?.userId)
        const newData: StockTypePostDto = this.dataForm.value;
        this.vehiclecongigService.updateStockType(newData).subscribe({
        
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
        const newData: StockTypePostDto = this.dataForm.value;
        newData.isActive = true;
        this.vehiclecongigService.addStockType(newData).subscribe({
          next: (res:ResponseMessage) => {
            if (res.success) {
              this.successAddMessage = res.message;
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData()
            }else {
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
    this.translate.get("Edit Stock Type").subscribe((res: string) => {
      this.editStockTypeText = res;
    });
    modelTitle.innerHTML =this.editStockTypeText ;
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
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
