import { Component, Input, OnInit } from "@angular/core";
import { UntypedFormBuilder, UntypedFormGroup, Validators } from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
 // Assuming you have a service to handle API calls
import { TranslateService } from "@ngx-translate/core";
import { FieldInspectionService } from "src/app/core/services/fieldInspectionService";
import { successToast } from "src/app/core/services/toast.service";
// Assuming you have a toast service

@Component({
  selector: "app-field-inspection",
  templateUrl: "./field-inspection.component.html",
  styleUrls: ["./field-inspection.component.scss"],
})
export class FieldInspectionComponent implements OnInit {
  @Input() vehicleId: any;
  fieldInspectionForm!: UntypedFormGroup;
  fieldInspections: any[] = [];
  currentFieldInspection: any;
  isEditing = false;

  constructor(
    private formBuilder: UntypedFormBuilder,
    private modalService: NgbModal,
    private fieldInspectionService: FieldInspectionService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.loadFieldInspections();
  }

  initializeForm() {
    this.fieldInspectionForm = this.formBuilder.group({
      vehicleId: ["", Validators.required],
      givenZoneId: [0, Validators.required],
      serviceChangeId: ["", Validators.required],
      width: [0, Validators.required],
      height: [0, Validators.required],
      length: [0, Validators.required],
      frontTyreSize: ["", Validators.required],
      rearTyreSize: ["", Validators.required],
      noOfRearAxel: [0, Validators.required],
      noOfFrontAxel: [0, Validators.required],
      axelDriveType: ["", Validators.required],
      numberOfTyre: [0, Validators.required],
      frontAxelMAxLoad: [0, Validators.required],
      rearAxelMaxLoad: [0, Validators.required],
      grossWeight: [0, Validators.required],
      tareWeight: [0, Validators.required],
      frontPlateSizeId: [0, Validators.required],
      backPlateSizeId: [0, Validators.required],
      createdById: ["", Validators.required],
    });
  }

  loadFieldInspections() {
    this.fieldInspectionService.getAllFieldInspections().subscribe((data: any) => {
      this.fieldInspections = data;
    });
  }

  openModal(content: any) {
    this.isEditing = false;
    this.fieldInspectionForm.reset();
    this.modalService.open(content, { size: "lg", centered: true });
  }

  saveFieldInspection() {
    if (this.fieldInspectionForm.valid) {
      if (this.isEditing) {
        this.updateFieldInspection();
      } else {
        this.createFieldInspection();
      }
    }
  }

  createFieldInspection() {
    // this.fieldInspectionService.createFieldInspection(this.fieldInspectionForm.value).subscribe(() => {
    //   this.translate.get("Field inspection successfully added").subscribe((res: string) => {
    //     successToast(res);
    //   });
    //   this.modalService.dismissAll();
    //   this.loadFieldInspections();
    // });
  }

  updateFieldInspection() {
    // this.fieldInspectionService.updateFieldInspection(this.fieldInspectionForm.value).subscribe(() => {
    //   this.translate.get("Field inspection successfully updated").subscribe((res: string) => {
    //     successToast(res);
    //   });
    //   this.modalService.dismissAll();
    //   this.loadFieldInspections();
    // });
  }

  editFieldInspection(fieldInspection: any, content: any) {
    this.isEditing = true;
    this.currentFieldInspection = fieldInspection;
    this.fieldInspectionForm.patchValue(fieldInspection);
    this.modalService.open(content, { size: "lg", centered: true });
  }
}
