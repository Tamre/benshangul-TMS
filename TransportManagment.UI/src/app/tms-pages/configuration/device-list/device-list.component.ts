import { Component, OnInit } from "@angular/core";
import { CommonModule, DatePipe } from "@angular/common";
import {
  UntypedFormGroup,
  UntypedFormBuilder,
  Validators,
} from "@angular/forms";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";

import { TranslateService } from "@ngx-translate/core";
import { cloneDeep } from "lodash";
import { ngxCsv } from "ngx-csv";
import { AddressService } from "src/app/core/services/address.service";
import { PaginationService } from "src/app/core/services/pagination.service";
import { successToast } from "src/app/core/services/toast.service";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { GlobalComponent } from "src/app/global-component";
import { Country } from "src/app/model/address/country";
import { DeviceGetDto, UserView } from "src/app/model/user";

import { UserProfileService } from "src/app/core/services/user.service";
import { ToastService } from "src/app/account/login/toast-service";

@Component({
  selector: "app-device-list",

  templateUrl: "./device-list.component.html",
  styleUrl: "./device-list.component.scss",
})
export class DeviceListComponent implements OnInit {
  dataForm!: UntypedFormGroup;
  masterSelected!: boolean;
  checkedList: any;

  alldeviceLists: DeviceGetDto[] = [];
  deviceLists: DeviceGetDto[] = [];
  selectedDevice!: DeviceGetDto;
  currentUser!: UserView | null;
  searchTerm: any;
  searchResults: any;

  breadCrumbItems = [
    { label: "Admin" },
    { label: "Device List", active: true },
  ];

  constructor(
    private modalService: NgbModal,
    public service: PaginationService,
    private formBuilder: UntypedFormBuilder,
    private toastService: ToastService,

    private datePipe: DatePipe,
    private addressService: AddressService,
    private tokenStorageService: TokenStorageService,
    public translate: TranslateService,

    private userService: UserProfileService
  ) {}

  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData();

    this.dataForm = this.formBuilder.group({
      approvedFor: ["", Validators.required],
      isActive: [false, Validators.required],
    });
  }

  refreshData() {
    this.userService.getDevices().subscribe({
      next: (res) => {
        if (res) {
          this.deviceLists = res;
          this.alldeviceLists = cloneDeep(res);
          this.deviceLists = this.service.changePage(this.alldeviceLists);
        }
      },
      error: (err) => {},
    });
  }

  changePage() {
    this.deviceLists = this.service.changePage(this.alldeviceLists);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.alldeviceLists.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.deviceLists = this.service.changePage(this.searchResults);
  }

  // Csv File Export
  csvFileExport() {
    var orders = {
      fieldSeparator: ",",
      quoteStrings: '"',
      decimalseparator: ".",
      showLabels: true,
      showTitle: true,
      title: "Country Data",
      useBom: true,
      noDownload: false,
      headers: [
        "name",
        "localName",
        "countryCode",
        "nationalityName",
        "localNationalityName",
        "createdById",
      ],
    };
    new ngxCsv(this.alldeviceLists, "Countries", orders);
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
    this.alldeviceLists = this.service.onSort(column, this.alldeviceLists);
    this.deviceLists = this.service.changePage(this.alldeviceLists);
  }

  activateDevice(id: any, content: any, data: DeviceGetDto) {
    this.selectedDevice = data;
    this.modalService.open(content, { size: "md", centered: true });
    this.dataForm.patchValue({
      isActive: this.selectedDevice.isActive,
      approvedFor: this.selectedDevice.approvedFor,
    });
  }

  updateDevice() {
    if (this.dataForm.valid) {
      this.userService
        .UpdateDevice({
          id: this.selectedDevice.id,
          approvedFor: this.dataForm.value.approvedFor,
          isActive: this.dataForm.value.isActive,
          approverId: this.currentUser?.userId,
          createdById:this.selectedDevice.createdById,
          pcnAme:this.selectedDevice.pcnAme,
          macAddress:this.selectedDevice.macAddress,
          ipAddress:this.selectedDevice.ipAddress,
        })
        .subscribe({
          next: (res) => {
            if (res.success) {
              this.toastService.show(res.message, {
                classname: "success text-white",
                delay: 2000,
              });
              this.refreshData();
              this.closeModal();
            } else {
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
  }
  closeModal() {
    this.modalService.dismissAll();
  }
}

