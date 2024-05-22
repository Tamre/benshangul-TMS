import { Component } from '@angular/core';
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

import { successToast } from 'src/app/core/services/toast.service';
import { DocTypePostDto } from 'src/app/model/vehicle-configuration/doc-type';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';

@Component({
  selector: 'app-document-type',
  templateUrl: './document-type.component.html',
  styleUrl: './document-type.component.scss'
})
export class DocumentTypeComponent {
  submitted = false;
  isEditing:Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allDocTypes?:any;
  docTypes?: any;

  successAddMessage : string = "";
  editDocumentText = "Edit Document Type";
  updateText = "Update";

  fileExtentionsDropDownItem = [
    { name: 'JPG', code: 'JPG'},
    { name: 'JPEG', code: 'JPEG'},
    { name: 'PNG', code: 'PNG'},
    { name: 'PDF', code: 'PDF'}
  ]

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
    public vehiclecongigService: VehicleConfigService,
  ) {}

  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      id: [""],
      fileName: ["", [Validators.required]],
      fileExtentions: ["", [Validators.required]],
      isPermanentRequired: [false],
      isTemporaryRequired:[false],
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
  openModal(content: any) {
    this.submitted = false;
    this.isEditing = false;
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  changePage() {
    this.docTypes = this.service.changePage(this.allDocTypes);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allDocTypes.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.docTypes = this.service.changePage(this.searchResults);
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
    this.allDocTypes = this.service.onSort(column, this.allDocTypes);
    this.docTypes = this.service.changePage(this.allDocTypes)
  }

  refreshData(){
    this.vehiclecongigService.getAllDocType().subscribe({
      next: (res) => {
        if (res) 
          {
            this.docTypes = res
            this.allDocTypes = cloneDeep(res);
            this.docTypes = this.service.changePage(this.allDocTypes)
            console.log(this.allDocTypes)
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
        const newData: DocTypePostDto = this.dataForm.value;
        this.vehiclecongigService.updateDocType(newData).subscribe({
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
        const newData: DocTypePostDto = this.dataForm.value;
        newData.isActive = true;
        // Set default values if not touched
        if (!this.dataForm?.get('isPermanentRequired')?.touched) {
          newData.isPermanentRequired = false;
        }
        if (!this.dataForm?.get('isTemporaryRequired')?.touched) {
          newData.isTemporaryRequired = false;
        }
        this.vehiclecongigService.addDocType(newData).subscribe({
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
    this.translate.get("Edit Document Type").subscribe((res: string) => {
      this.editDocumentText = res;
    });
    modelTitle.innerHTML =this.editDocumentText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.docTypes[id];
    this.dataForm.controls["fileName"].setValue(this.econtent.fileName);
    this.dataForm.controls["fileExtentions"].setValue(this.econtent.fileExtentions);
    this.dataForm.controls["isPermanentRequired"].setValue(this.econtent.isPermanentRequired);
    this.dataForm.controls["isTemporaryRequired"].setValue(
      this.econtent.isTemporaryRequired
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
  }
}
