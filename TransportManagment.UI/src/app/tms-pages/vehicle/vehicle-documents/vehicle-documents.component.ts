import { Component, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { VehicleDropdownService } from "src/app/core/services/vehicle-dropdown.service";
import { ISettingDropDownsDto } from "src/app/model/common";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { VehicleService } from "src/app/core/services/vehicle.service";

@Component({
  selector: "app-vehicle-documents",

  templateUrl: "./vehicle-documents.component.html",
  styleUrl: "./vehicle-documents.component.scss",
})
export class VehicleDocumentsComponent implements OnInit {
  documentTypes: ISettingDropDownsDto[] = [];

  vehicleDocumentForm!: FormGroup;

  constructor(
    private vehcDropDownService: VehicleDropdownService,
    private fb: FormBuilder,
    private vehicleService: VehicleService
  ) {}

  ngOnInit(): void {
    this.getDocumentTypes();
    this.vehicleDocumentForm = this.fb.group({
      vehicleId: ["F2C9050E-38A9-4C67-A14A-054F134E2A2C", Validators.required],
      createdById: [
        "18eef146-fc48-4074-94e7-e5dd4a3be236",
        Validators.required,
      ],
      document: [null, Validators.required],
      documentTypeId: [1, Validators.required],
      forVehicleDocument: [0, Validators.required],
    });
  }

  getDocumentTypes() {
    this.vehcDropDownService.getDocumentTypeDropdown().subscribe({
      next: (res) => {
        this.documentTypes = res;
      },
    });
  }

  onSubmit() {
    if (this.vehicleDocumentForm.valid) {
      const formData = new FormData();
      formData.append(
        "VehicleId",
        this.vehicleDocumentForm.get("vehicleId")?.value
      );
      formData.append(
        "CreatedById",
        this.vehicleDocumentForm.get("createdById")?.value
      );
      formData.append(
        "Document",
        this.vehicleDocumentForm.get("document")?.value
      );
      formData.append(
        "DocumentTypeId",
        this.vehicleDocumentForm.get("documentTypeId")?.value
      );
      formData.append(
        "ForVehicleDocument",
        this.vehicleDocumentForm.get("forVehicleDocument")?.value
      );

      // Use formData to submit the form
      console.log(formData);

      this.vehicleService.addVehicleDoc(formData).subscribe({
        next: (res) => {
          console.log(res);
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
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
