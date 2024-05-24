import { Component, OnInit } from "@angular/core";
import {
  UntypedFormGroup,
  UntypedFormBuilder,
  Validators,
} from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

import { TranslateService } from "@ngx-translate/core";
import { number } from "echarts";
import { cloneDeep } from "lodash";
import { ToastService } from "src/app/account/login/toast-service";
import { VehicleConfigService } from "src/app/core/services/Vehicle-services/vehicle-config.service";
import { VehicleService } from "src/app/core/services/Vehicle-services/vehicle.service";

import { AddressService } from "src/app/core/services/address.service";
import { PaginationService } from "src/app/core/services/pagination.service";
import { successToast, errorToast } from "src/app/core/services/toast.service";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { ResponseMessage } from "src/app/model/ResponseMessage.Model";
import { UserView } from "src/app/model/user";
import { GetVehicleDetailRequestDto, VehicleData, VehicleDetailDto } from "src/app/model/vehicle";
import { VehicleModelPostDto } from "src/app/model/vehicle-configuration/vehicle-model";


@Component({
  selector: "app-vehicle-list",
  templateUrl: "./vehicle-list.component.html",
  styleUrls: ["./vehicle-list.component.scss"],
})
export class VehicleListComponent implements OnInit {
  submitted = false;
  vehicleForm!: UntypedFormGroup;
  searchForm!: UntypedFormGroup;
  searchValueForm!: UntypedFormGroup;
  isEditing: Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;
  econtent?: any;
  vehicleDetail!: VehicleDetailDto ;

  allVehicleModels?: any;
  vehicleModels?: any;
  vehicle?: any;
  allVehLookups?: any;
  vehLookups?: any;
  markId: number = 0;
  markNames: string[] = [];
  markNameIdMap: { [name: string]: number } = {};
  isvehicleFound?: boolean = false;

  breadCrumbItems = [
    { label: "VRMS" },
    { label: "Vehicle Details", active: true },
  ];

  horsePowerMeasureDropDownItem = [
    { name: "BHP", code: "BHP" },
    { name: "KW", code: "OTHEKWR" },
  ];
  searchDropDownItem = [
    { name: "RegistrationNo", code: 0 },
    { name: "PlateNo", code: 1 },
    { name: "ChessisNo", code: 2 },
    { name: "EngineNo", code: 3 },
  ];

  searchDropDown2Item = [
    { name: "PERMANENT", code: 2 },
    { name: "TEMPORARY", code: 1 },
    { name: "ENCODED", code: 0 },
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
  taxStatusOption: any[] = [{ name: "TAX_PAID" }, { name: "FREE" }];

  selectedModelId: any;

  successAddMessage: string = "";
  successUpdateMessage = "Vehicle Type successfully updated";
  editPlateTypeText = "Edit Vehicle Type";
  updateText = "Update";
  countries: any;
  zones: any;
  showZoneInput = false;
  showRegionInput = false;

  searchType: string = "";
  search: string = "";
  searchregistrationType: string = "";

  vehicleId: string = "";
  vehicleRegistrationNo: string = "";
  isRegistrationType: boolean = false;
 // groupData = groupData;

 
 vehicleActionList: any[] = [
  { code: 1, name: "Profile" },
  { code: 2, name: "Dcouments" },
  { code: 3, name: "Owners" },
  { code: 4, name: "Plates" },
  { code: 5, name: "ORC" },  
  { code: 6, name: "Annual Inspection" },
  { code: 7, name: "Change Cases" },
  { code: 8, name: "Valuations" },
  { code: 9, name: "Transfers" },
  { code: 10, name: "Ban Cancel & Lost" },
];

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
   
    public vehicleCongigService: VehicleConfigService,
    private addressService: AddressService,
    public vehicleService: VehicleService,
    private toastService: ToastService
  ) {}
  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData();
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

    this.searchForm = this.formBuilder.group({
      searchType: ["", Validators.required],
      search: ["", Validators.required],
      searchregistrationType: ["", Validators.required],
    });
    this.searchValueForm = this.formBuilder.group({
      vehicleFileteParameter: [2, Validators.required],
      value: ["", Validators.required],
      regionalUser: [true],
      registrationType: [0],
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
      taxStatus: ["", Validators.required],
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
      createdById: [""],
      lastActionTaken: ["Endoding"],
    });

  }
  activeTab: number = 1;

  setActiveTab(tab: number) {
    this.activeTab = tab;
  }
  // Convenience getter for easy access to form fields
  get f() {
    return this.vehicleForm.controls;
  }



  changeType(type:any){
    this.isRegistrationType = false;
    if(type == 0){
      this.isRegistrationType = true;
    }
  }

  submitSearch() {
    if (this.search == null) {
      return;
    }
    var data = this.searchForm.value;

    this.searchValueForm.controls["value"].setValue(data.search);
    this.searchValueForm.controls["vehicleFileteParameter"].setValue(
      data.searchType
    );
    this.searchValueForm.controls["registrationType"].setValue(
      data.searchregistrationType
    );

    var value = this.searchValueForm.value;

    this.vehicleService.getVehicleDetail(value).subscribe({
      next: (data) => {
        debugger;
        if (data.id) {
          this.isvehicleFound = true;
          this.vehicleDetail = data;

          this.vehicleId = data.id;
          this.vehicleRegistrationNo = data.registrationNumber;
          this.toastService.show("found a vehicle", {
            classname: "success text-white",
            delay: 2000,
          });
        } else {
          this.toastService.show("vehicle not found", {
            classname: "error text-white",
            delay: 2000,
          });
        }
      },
      error: (err) => {
        errorToast(err);
      },
    });
  }

  // Function to submit the form
  submitForm() {
    this.submitted = true;
    this.vehicleForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.vehicle = this.vehicleForm.value;

    // Stop here if form is invalid
    if (this.vehicleForm.invalid) {
      return;
    }

    // Populate vehicle object with form values
    this.vehicle = this.vehicleForm.value;

    // // Call the service to add the vehicle
    this.vehicleService.addVehicleList(this.vehicle).subscribe({
      next: (res) => {
        if (res.success) {
          successToast(res.message);
          this.refreshData();
        }
      },
      error: (err) => {
        errorToast(err);
      },
    });
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
    this.vehicleCongigService.getAllVehicleModel().subscribe({
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



  /**
   * Form data get
   */
  get form() {
    return this.dataForm.controls;
  }
}
