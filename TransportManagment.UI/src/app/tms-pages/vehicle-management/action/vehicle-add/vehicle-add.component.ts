import { Component, OnInit } from "@angular/core";
import {
  UntypedFormGroup,
  UntypedFormBuilder,
  Validators,
  FormGroup,
} from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

import { TranslateService } from "@ngx-translate/core";
import { cloneDeep } from "lodash";
import { VehicleConfigService } from "src/app/core/services/Vehicle-services/vehicle-config.service";
import { VehicleService } from "src/app/core/services/Vehicle-services/vehicle.service";
import { AddressService } from "src/app/core/services/address.service";
import { PaginationService } from "src/app/core/services/pagination.service";
import { successToast,errorToast } from "src/app/core/services/toast.service";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { ResponseMessage } from "src/app/model/ResponseMessage.Model";
import { UserView } from "src/app/model/user";
import { VehicleModelPostDto } from "src/app/model/vehicle-configuration/vehicle-model";
import { IVehicleRegisterTabDto } from "./IVehicleRegisterDto";
import { ToastService } from "src/app/account/login/toast-service";


@Component({
  selector: "app-vehicle-add",
  templateUrl: "./vehicle-add.component.html",
  styleUrls: ["./vehicle-add.component.scss"],
})

/**
 * Layouts Component
 */
export class VehicleAdd implements OnInit {
  submitted = false;
  vehicleForm!: UntypedFormGroup;
  isEditing: Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;

  allVehicleModels?: any;
  vehicleModels?: any;
  vehicle?: any;
  allVehLookups?: any;
  vehLookups?: any;
  markId: number = 0;
  markNames: string[] = [];
  markNameIdMap: { [name: string]: number } = {};
  activeIdd:number=1

 registerdVehicle:IVehicleRegisterTabDto={
  vehicleId: '',

 }
// registerdVehicle:IVehicleRegisterTabDto = {
//   vehicleId:'F2C9050E-38A9-4C67-A14A-054F134E2A2C',
//   vehicleRegNo:'strin-RN00002',
//   vehicleChasis:'17',
//   owner:"kirubel",
//   vehicleDocuments:['File 1 ', 'Annual Inspection', 'File 3']
// }

isRegisterdFinished:boolean = false;




  breadCrumbItems = [
    { label: "VRMS" },
    { label: "Registration", active: true },
  ];

  horsePowerMeasureDropDownItem = [
    { name: "BHP", code: "BHP" },
    { name: "KW", code: "OTHEKWR" },
  ];
  modelOptions: any[] = [
    { modelName: "Model 1", modelId: 1 },
    { modelName: "Model 2", modelId: 2 },
    { modelName: "Model 3", modelId: 3 },
  ];

  horsePowerMeasureOption: any[] = [{ name: "BHP" }, { name: "KW" }];
  typeOfVehicleOption: any[] = [{ name: "VEHICLE" }, { name: "TRAILER" }];
  vehicleCurrentStatusOption: any[] = [
    { name: "New_Vehicle" },
    { name: "Drived_Vehicle" },
  ];
  transferStatusOption: any[] = [
    { name: "New" },
    { name: "FromZone" },
    { name: "FromOtherRegion" },
    { name: "ToZone" },
    { name: "ToOtherRegion" },
  ];
  taxStatusOption: any[] = [
    { name: "TAX_PAID" },
    { name: "FREE" },
  ];

  selectedModelId: any;

  successAddMessage: string = "";
  successUpdateMessage = "Vehicle Type successfully updated";
  editPlateTypeText = "Edit Vehicle Type";
  updateText = "Update";
  countries: any;
  zones: any;
  showZoneInput = false;
  showRegionInput = false;

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
    private toastService : ToastService,
    public vehicleConfigService: VehicleConfigService,
    private addressService: AddressService,
    public vehicleService:VehicleService
  ) {

  }
  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData();
    this.getMark();
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      id: [""],
      name: ["", [Validators.required]],
      engineCapacity: [
        "",
        [Validators.required, Validators.pattern(/^-?\d+$/)],
      ],
      noOfCylinder: ["", [Validators.required, Validators.pattern(/^-?\d+$/)]],
      horsePowerMeasure: ["", [Validators.required]],
      markId: ["", [Validators.required]],
      createdById: [this.currentUser?.userId, [Validators.required]],
      isActive: [true],
    });
    this.vehicleForm = this.formBuilder.group({
      // Required field
      modelId: ["", Validators.required],
      officeCode: [""], // No validators
      declarationNo: ["", Validators.required], // Required field
      declarationDate: ["", Validators.required], // Required field
      billOfLoading: [""], // No validators
      removalNumber: [""], // No validators
      invoiceDate: [""],
      invoicePrice: [""],
      taxStatus:["", Validators.required],
      chassisNo: ["", Validators.required], // Required field
      engineNumber: [""], // No validators
      assembledCountryId: ["", Validators.required],
      chassisMadeId: ["", Validators.required],
      manufacturingYear: ["", Validators.required],
      horsePower: ["", Validators.required],
      horsePowerMeasure: ["", Validators.required],
      noCylinder: ["", Validators.required],
      engineCapacity: ["", Validators.required],
      typeOfVehicle: ["", Validators.required],
      vehicleCurrentStatus: ["", Validators.required],
      transferStatus: ["", Validators.required],
      serviceZoneId: ["", Validators.required],
      createdById:[""],
      lastActionTaken:["Endoding"]
    });

    if(this.registerdVehicle.vehicleId!=''){
      this.activeIdd=2
    }
  
  }
  // Convenience getter for easy access to form fields
  get f() {
    return this.vehicleForm.controls;
  }

   onSelectionChange(event :any) {
        const selectedValue = event.name;
        if (selectedValue === 'FromZone') {
            this.showZoneInput = true;
            this.showRegionInput = false;
        } else if (selectedValue === 'FromOtherRegion') {
            this.showZoneInput = false;
            this.showRegionInput = true;
        } else {
            this.showZoneInput = false;
            this.showRegionInput = false;
        }
    }

  // Function to submit the form
  submitForm() {
    this.submitted = true;
    this.vehicleForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.vehicle = this.vehicleForm.value;
    console.log(this.vehicle);
    // Stop here if form is invalid
    if (this.vehicleForm.invalid) {
      return;
    }

    // Populate vehicle object with form values
    this.vehicle = this.vehicleForm.value;
    console.log(this.vehicle);
    // // Call the service to add the vehicle
    this.vehicleService.addVehicleList(this.vehicle).subscribe({
      next: (res) => {
        if (res.success) {       

                  

          this.toastService.show(res.message, {
            classname: "success text-white",
            delay: 2000,
          });

        

          this.registerdVehicle.vehicleId = res.data.vehicleId;
          this.registerdVehicle.vehicleChasis= res.data.vehicleChasis;
          this.registerdVehicle.vehicleRegNo = res.data.vehicleRegNo

          this.setActiveTab(2);
        }else {
          this.toastService.show(res.message, {
            classname: "error text-white",
            delay: 2000,
          });
        }
      },
      error: (err) => {
        this.toastService.show(err.message, {
          classname: "error text-white",
          delay: 2000,
        });
      },
      
    });
  }

  selectedAccount = "This is a placeholder";
  Default = [{ name: "Choice 1" }, { name: "Choice 2" }, { name: "Choice 3" }];

  getMark() {
    this.vehicleConfigService.getVehicleLookup(this.markId).subscribe({
      next: (res) => {
        if (res) {
          this.vehLookups = res;
          this.allVehLookups = cloneDeep(res);
          this.vehLookups = this.service.changePage(this.allVehLookups);
          console.log(this.allVehLookups);

          // Populate the markNames array with names from vehLookups
          this.markNames = this.vehLookups.map((veh: any) => veh.name);
        }
        // Populate the markNameIdMap with name-ID mapping
        this.markNameIdMap = this.vehLookups.reduce((map: any, veh: any) => {
          map[veh.name] = veh.id;
          return map;
        }, {});
      },
      error: (err) => {},
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
    this.vehicleModels = this.service.changePage(this.allVehicleModels);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allVehicleModels.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.vehicleModels = this.service.changePage(this.searchResults);
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
    this.allVehicleModels = this.service.onSort(column, this.allVehicleModels);
    this.vehicleModels = this.service.changePage(this.allVehicleModels);
  }
  refreshData() {
  
    this.vehicleConfigService.getAllVehicleModel().subscribe({
      next: (res) => {
        if (res) {
          this.vehicleModels = res;
          this.allVehicleModels = cloneDeep(res);
          this.vehicleModels = this.service.changePage(this.allVehicleModels);
        }
      },
      error: (err) => {},
    });
    this.addressService.getAllCountries().subscribe({
      next: (res) => {
        if (res) {
          this.countries = res;
        }
      },
      error: (err) => {},
    });
    this.addressService.getAllZone().subscribe({
      next: (res) => {
        if (res) {
          this.zones = res;
        }
      },
      error: (err) => {},
    });
  }

  saveData() {
    const updatedData = this.dataForm.value;

    if (this.dataForm.valid) {
      if (this.dataForm.get("id")?.value) {
        console.log(this.currentUser?.userId);
        const newData: VehicleModelPostDto = this.dataForm.value;
        this.vehicleConfigService.updateVehicleModel(newData).subscribe({
          next: (res: ResponseMessage) => {
            if (res.success) {
             

              this.toastService.show(res.message, {
                classname: "success text-white",
                delay: 2000,
              });


              this.registerdVehicle.vehicleId = res.data.vehicleId;
              this.registerdVehicle.vehicleChasis= res.data.vehicleChasis;
              this.registerdVehicle.vehicleRegNo = res.data.vehicleRegNo


              this.dataForm.reset();
              this.refreshData();

              this.setActiveTab(2);


            } else {
              console.error(res.message);
            }
          },
          error: (err) => {
            console.error(err);
          },
        });
      } else {
        const newData: VehicleModelPostDto = this.dataForm.value;
        newData.isActive = true;
        this.vehicleConfigService.addVehicleModel(newData).subscribe({
          next: (res: ResponseMessage) => {
            if (res.success) {
              
                      

              this.toastService.show(res.message, {
                classname: "success text-white",
                delay: 2000,
              });


              this.registerdVehicle.vehicleId = res.data.vehicleId;
              this.registerdVehicle.vehicleChasis= res.data.vehicleChasis;
              this.registerdVehicle.vehicleRegNo = res.data.vehicleRegNo

              this.refreshData();

              this.setActiveTab(2);
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

  setActiveTab(value: number) {

    console.log(value);
    this.activeIdd= value

    if (this.activeIdd==4) {
      this.isRegisterdFinished = true;
    }
  }
  onNavLinkClick(event: Event): void {
    event.preventDefault();  // This will prevent the default action of the link
    // Add any additional logic if needed
  }
}
