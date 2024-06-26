import { Component } from '@angular/core';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { TranslateService } from '@ngx-translate/core';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

import { cloneDeep } from 'lodash';

import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { successToast } from 'src/app/core/services/toast.service';
import { FactoryPointPostDto, FactoryPointUpdateDto } from 'src/app/model/vehicle-configuration/factory-point';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';

@Component({
  selector: 'app-factory-point',
  templateUrl: './factory-point.component.html',
  styleUrl: './factory-point.component.scss'
})
export class FactoryPointComponent {

  submitted = false;
  isEditing: Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allFactoryPoints?: any;
  factoryPoints?: any;

  allVehLookups?: any;
  vehLookups?: any;
  markId: number = 0;
  markNames: string[] = [];
  markNameIdMap: { [name: string]: number } = {};

  markName: string[] = [];
  selectedMarkName: { id: number; name: string } | null = null;

  successAddMessage: string = "";
  editFactoryPointText = "Edit Factory Type";
  updateText = "Update";

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
 
    public vehicleConfigService: VehicleConfigService
  ) { }

  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()
    this.getMark()
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      id: [""],
      value: ["", [Validators.required],this.floatValidator],
      markName: [""],
      markId: ["", [Validators.required]],
      createdById: [this.currentUser?.userId, [Validators.required]],
      isActive:[true]
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

  getMark() {
    this.vehicleConfigService.getVehicleLookup(this.markId).subscribe({
      next: (res) => {
        if (res) {
          this.vehLookups = res
          this.allVehLookups = cloneDeep(res);
          this.vehLookups = this.service.changePage(this.allVehLookups)
          console.log(this.allVehLookups)
          
          this.markName = this.allVehLookups.map((veh: any) => ({
            id: veh.id,
            name: veh.name,
          }));

          
        }
       
      
      },
      error: (err) => {

      },
    });
  }
  openModal(content: any) {
    //this.getMark()
    this.submitted = false;
    this.isEditing = false;
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  changePage() {
    this.factoryPoints = this.service.changePage(this.allFactoryPoints);
  }
  // Search Data
  performSearch(): void {
    this.searchResults = this.allFactoryPoints.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.factoryPoints = this.service.changePage(this.searchResults);
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
    this.allFactoryPoints = this.service.onSort(column, this.allFactoryPoints);
    this.factoryPoints = this.service.changePage(this.allFactoryPoints)
  }
  refreshData() {
    this.vehicleConfigService.getAllFactoryPoint().subscribe({
      next: (res) => {
        if (res) {
          this.factoryPoints = res
          this.allFactoryPoints = cloneDeep(res);
          this.factoryPoints = this.service.changePage(this.allFactoryPoints)
          console.log(this.allFactoryPoints)
          
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
        const newData: FactoryPointUpdateDto = this.dataForm.value;
        newData.markName
        this.vehicleConfigService.updateFactoryPoint(newData).subscribe({
          next: (res: ResponseMessage) => {
            if (res.success) {
              this.successAddMessage = res.message;
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData();
            } else {
              console.error(res.message);
            }
          },
          error: (err) => {
            console.error(err);
          },
        });

      } else { 
        const newData: FactoryPointPostDto = this.dataForm.value;
        this.vehicleConfigService.addFactoryPoint(newData).subscribe({
          next: (res: ResponseMessage) => {
            if (res.success) {
              this.successAddMessage = res.message;
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData();
            } else {
              console.error(res.message);
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
    //this.getMark()
    this.submitted = false;
    this.modalService.open(content, { size: "lg", centered: true });
    var modelTitle = document.querySelector(".modal-title") as HTMLAreaElement;
    this.translate.get("Edit Vehicle Type").subscribe((res: string) => {
      this.editFactoryPointText = res;
    });
    modelTitle.innerHTML = this.editFactoryPointText;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText = res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.factoryPoints[id];
    this.dataForm.controls["value"].setValue(this.econtent.value);
    this.dataForm.controls["markId"].setValue(this.econtent.markId);
    
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
