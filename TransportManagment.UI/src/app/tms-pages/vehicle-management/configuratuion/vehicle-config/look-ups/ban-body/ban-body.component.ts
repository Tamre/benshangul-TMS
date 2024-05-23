import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { TranslateService } from '@ngx-translate/core';
import { RootReducerState } from 'src/app/store';
import { Store } from '@ngrx/store';
import { UserView } from 'src/app/model/user';
import { BanBodyPostDto } from 'src/app/model/vehicle-configuration/ban-body';
import { successToast } from 'src/app/core/services/toast.service';
import { cloneDeep } from 'lodash';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';

@Component({
  selector: 'app-ban-body',
  templateUrl: './ban-body.component.html',
  styleUrl: './ban-body.component.scss'
})
export class BanBodyComponent implements OnInit{
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allBan?:any;
  banBody?: any;

  successAddMessage : string = "";
  successUpdateMessage :string = "";
  editBanBodyText = "Edit Ban Body";
  updateText = "Update";

  banBodyCategoryDropDownItem = [
    { name: 'Bank', code: 'BANK'},
    { name: 'Court', code: 'COURT'},
    { name: 'Other', code: 'OTHER'}
  ]

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
    public vehicleService: VehicleConfigService,
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
      banBodyCategory:["",[Validators.required]],
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
  banBodyCategoryName(code: string): string {
    const banBodyCategory = this.banBodyCategoryDropDownItem.find(item => item.code === code);
    return banBodyCategory ? banBodyCategory.name : code;
  }
  changePage() {
    this.banBody = this.service.changePage(this.allBan);
  }
  refreshData(){
    this.vehicleService.getAllBanBody().subscribe({
      next: (res) => {
        if (res) 
          {
            this.banBody = res
            this.allBan = cloneDeep(res);
            this.banBody = this.service.changePage(this.allBan)
            console.log(this.allBan)
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
    this.searchResults = this.allBan.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.banBody = this.service.changePage(this.searchResults);
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
    this.allBan = this.service.onSort(column, this.allBan);
    this.banBody = this.service.changePage(this.allBan)
  }
  //save
  saveData() {
    const updatedData = this.dataForm.value;
   
    if (this.dataForm.valid) {
      if (this.dataForm.get("id")?.value) {
        const newData: BanBodyPostDto = this.dataForm.value;
        this.vehicleService.updateBanBody(newData).subscribe({
          next: (res:ResponseMessage) => {
            if (res.success) {
              this.successUpdateMessage=res.message;
              this.closeModal();
              successToast(this.successUpdateMessage);
              this.refreshData()
            }
          },
          error: (err) => {},
        });

      } else {
        const newData: BanBodyPostDto = this.dataForm.value;
        newData.isActive = true;
        this.vehicleService.addBanBody(newData).subscribe({
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
    this.translate.get("Edit Ban Body").subscribe((res: string) => {
      this.editBanBodyText = res;
    });
    modelTitle.innerHTML =this.editBanBodyText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.banBody[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    //this.dataForm.controls["code"].setValue(this.econtent.code);
    this.dataForm.controls["banBodyCategory"].setValue(
      this.econtent.banBodyCategory
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
