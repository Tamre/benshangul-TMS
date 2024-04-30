import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { TranslateService } from '@ngx-translate/core';
import { RootReducerState } from 'src/app/store';
import { Store } from '@ngrx/store';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { cloneDeep } from 'lodash';
import { VehicleLookupService } from 'src/app/core/services/vehicle-config-services/vehicle-lookup.service';
import { VehicleLookupPostDto } from 'src/app/model/vehicle-configuration/vehicle-lookup';
import { successToast } from 'src/app/core/services/toast.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Component({
  selector: 'app-vehicle-lookups',
  templateUrl: './vehicle-lookups.component.html',
  styleUrl: './vehicle-lookups.component.scss'
})
export class VehicleLookupsComponent {
  @Input() tabValue: number | undefined;

  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allVehLookups?:any;
  vehLookups?: any;

  successAddMessage = "Ban Body successfully added";
  successUpdateMessage = "Ban Body successfully updated";
  editBanBodyText = "Edit Ban Body";
  updateText = "Update";

  VehicleLookupTypeEnum = [
    { name: 'Mark', code: '0'},
    { name: 'Ban Case', code: '1'},
    { name: 'Plate Size', code: '2'},
    { name: 'Vehicle Category', code: '3'},
    { name: 'Vehicle Color', code: '4'},
    { name: 'Major', code: '5'},
    { name: 'Minor', code: '6'},
    { name: 'Load Measurement', code: '7'},

  ]
  

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
    public vehicleLookupService:VehicleLookupService
  ) {

  }
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
      vehicleLookupType:["",[Validators.required]],
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
  changePage() {
    this.vehLookups = this.service.changePage(this.allVehLookups);
  }
  refreshData(){
    if (this.tabValue != null) {
    this.vehicleLookupService.getVehicleLookup(this.tabValue).subscribe({
      next: (res) => {
        if (res) 
          {
            this.vehLookups = res
            this.allVehLookups = cloneDeep(res);
            this.vehLookups = this.service.changePage(this.allVehLookups)
            console.log(this.allVehLookups)
          }
      },
      error: (err) => {
        
      },
    });}
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
    this.searchResults = this.allVehLookups.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.vehLookups = this.service.changePage(this.searchResults);
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
    this.allVehLookups = this.service.onSort(column, this.allVehLookups);
    this.vehLookups = this.service.changePage(this.allVehLookups)
  }
  //save
  saveData() {
    const updatedData = this.dataForm.value;
   
    if (this.dataForm.valid) {
      if (this.dataForm.get("id")?.value) {
        //console.log(this.currentUser?.userId)
        const newData: VehicleLookupPostDto = this.dataForm.value;
        this.vehicleLookupService.updateVehicleLookup(newData).subscribe({
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
        const newData: VehicleLookupPostDto = this.dataForm.value;
        //newData.isActive = true;
        this.vehicleLookupService.addVehicleLookup(newData).subscribe({
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
    this.translate.get("Edit Vehicle Lookup").subscribe((res: string) => {
      this.editBanBodyText = res;
    });
    modelTitle.innerHTML =this.editBanBodyText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.vehLookups[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    this.dataForm.controls["vehicleLookupType"].setValue(
      this.econtent.vehicleLookupType
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
