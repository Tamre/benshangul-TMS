import { Component, Input, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";

import { ISettingDropDownsDto } from "src/app/model/common";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

import { UserView } from "src/app/model/user";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { ToastService } from "src/app/account/login/toast-service";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { VehicleDropdownService } from "src/app/core/services/Vehicle-services/vehicle-drop-down.service";
import { VehicleService } from "src/app/core/services/Vehicle-services/vehicle.service";
import { IVehicleDocumentGetDto } from "./IVehicleDocuemntsDto";
import { CommonService } from "src/app/core/services/common.service";

@Component({
  selector: "app-vehicle-documents",

  templateUrl: "./vehicle-documents.component.html",
  styleUrl: "./vehicle-documents.component.scss",
})
export class VehicleDocumentsComponent implements OnInit {
  @Input() vehicleId: any;
  documentTypes: ISettingDropDownsDto[] = [];
  searchTerm: any;
  vehicleDocumentForm!: FormGroup;
  vehicleDocumentList!: IVehicleDocumentGetDto[];
  selectedVehcDoc!: IVehicleDocumentGetDto;
  currentUser!: UserView | null;
  sortField: any;
  sortBy: any;
  submitted = false;
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
  onSort(column: any) {}
  csvFileExport() {}
  constructor(
    private modalService: NgbModal,
    private vehcDropDownService: VehicleDropdownService,
    private fb: FormBuilder,
    private vehicleService: VehicleService,
    private tokenStorageService: TokenStorageService,
    private toastService: ToastService,
    private commonService : CommonService

  ) {}

  openModal(content: any) {
    this.submitted = false;
    this.vehicleDocumentForm.reset();
    this.modalService.open(content, { size: "lg", backdrop: "static" });
  }

  viewFile(content:any,selectedDoc: IVehicleDocumentGetDto) {

    this.selectedVehcDoc = selectedDoc;
    
    this.modalService.open(content, { size: "xl",centered:true, backdrop: "static" });
  }


  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.vehicleDocumentForm = this.fb.group({
      document: [null, Validators.required],
      documentTypeId: [null, Validators.required],
    });

    this.getDocumentTypes();

    if (this.vehicleId) {
      this.getVehicleDocuments();
    }
  }

  getVehicleDocuments() {
    this.vehicleService.getVehicleDocuemnts(this.vehicleId).subscribe({
      next: (res) => {
        this.vehicleDocumentList = res;
      },
    });
  }

  getDocumentTypes() {
    this.vehcDropDownService.getDocumentTypeDropdown().subscribe({
      next: (res) => {
        if (res) {
          this.documentTypes = res;
        }
      },
      error: (err) => {},
    });
  }

  closeModal() {
    this.modalService.dismissAll();
  }
  onSubmit() {
    if (this.vehicleDocumentForm.valid) {
      const formData = new FormData();
      let userId = this?.currentUser?.userId;
      console.log("vehicle", this.vehicleId);
      formData.append("VehicleId", this.vehicleId);
      if (userId) formData.append("CreatedById", userId);
      formData.append(
        "Document",
        this.vehicleDocumentForm.get("document")?.value
      );
      formData.append(
        "DocumentTypeId",
        this.vehicleDocumentForm.get("documentTypeId")?.value
      );

      this.vehicleService.addVehicleDoc(formData).subscribe({
        next: (res) => {
          this.toastService.show(res.message, {
            classname: "success text-white",
            delay: 2000,
          });
          this.submitted = true;
          this.getVehicleDocuments()
          this.closeModal()
        },
        error: (err) => {
          this.toastService.show("unable to add document", {
            classname: "error text-white",
            delay: 2000,
          });
        },
      });
    }
  }

  getImageUrl(filePath:string){

    return this.commonService.getImageUrl(filePath)
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.vehicleDocumentForm.patchValue({
        document: file,
      });
    }
  }
}
