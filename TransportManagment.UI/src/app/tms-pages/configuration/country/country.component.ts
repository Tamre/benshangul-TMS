import { Component, OnInit } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  UntypedFormArray,
  UntypedFormControl,
  Validators,
} from "@angular/forms";

// Date Format
import { DatePipe } from "@angular/common";
// Csv File Export
import { ngxCsv } from "ngx-csv/ngx-csv";

// Rest Api Service
import { restApiService } from "../../../core/services/rest-api.service";
import { GlobalComponent } from "../../../global-component";

// Sweet Alert
import Swal from "sweetalert2";

import { Store } from "@ngrx/store";
import { RootReducerState } from "src/app/store";
import {
  addContact,
  deleteContact,
  fetchCrmContactData,
  updateContact,
} from "src/app/store/CRM/crm_action";
import {
  selectCRMLoading,
  selectContactData,
} from "src/app/store/CRM/crm_selector";
import { cloneDeep } from "lodash";
import { PaginationService } from "src/app/core/services/pagination.service";
import { AddressService } from "src/app/core/services/address.service";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { Country } from "src/app/model/country";
import { UserView } from "src/app/model/user";
import { TranslateService } from "@ngx-translate/core";
import { successToast } from "src/app/core/services/toast.service";

@Component({
  selector: "app-country",
  templateUrl: "./country.component.html",
  styleUrls: ["./country.component.scss"],
})

/**
 * Contacts Component
 */
export class CountryComponent implements OnInit {
  // bread crumb items
  breadCrumbItems!: Array<{}>;
  submitted = false;
  contactsForm!: UntypedFormGroup;
  dataForm!: UntypedFormGroup;
  masterSelected!: boolean;
  checkedList: any;

  // Api Data
  content?: any;
  contacts?: any;
  econtent?: any;
  url = GlobalComponent.API_URL;
  allcontacts: any;
  searchTerm: any;
  searchResults: any;
  allcountries?:any;
  countries?: any;
  currentUser!: UserView | null;
  isEditing:Boolean = false;
  successAddMessage = "country successfully added"; 
  successUpdateMessage = "country successfully updated"
 
  constructor(
    private modalService: NgbModal,
    public service: PaginationService,
    private formBuilder: UntypedFormBuilder,
    private restApiService: restApiService,
    private store: Store<{ data: RootReducerState }>,
    private datePipe: DatePipe,
    private addressService: AddressService,
    private tokenStorageService: TokenStorageService,
    public translate: TranslateService
  ) {}

  ngOnInit(): void {
    /**
     * BreadCrumb
     */
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()
    

    this.breadCrumbItems = [
      { label: "Address" },
      { label: "Countries", active: true },
    ];

    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      id: [""],
      name: ["", [Validators.required]],
      localName: ["", [Validators.required]],
      countryCode: ["", [Validators.required]],
      nationalityName: ["", [Validators.required]],
      localNationalityName: ["", [Validators.required]],
      createdById: [this.currentUser?.id, [Validators.required]],
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

  refreshData(){
    this.addressService.getAllCountries().subscribe({
      next: (res) => {
        if (res) 
          {
            this.countries = res
            this.allcountries = cloneDeep(res);
            this.countries = this.service.changePage(this.allcountries)
          }
      },
      error: (err) => {
        
      },
    });
  }

  changePage() {
    this.countries = this.service.changePage(this.allcountries);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allcountries.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.countries = this.service.changePage(this.searchResults);
  }

  /**
   * Open modal
   * @param content modal content
   */
 
  openModal(content: any) {
    this.submitted = false;
    this.isEditing = false;
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.id);
    this.modalService.open(content, { size: "md", centered: true });
  }

  /**
   * Form data get
   */
  get form() {
    return this.dataForm.controls;
  }


  saveData() {
    const updatedData = this.dataForm.value;
   
    if (this.dataForm.valid) {
      if (this.dataForm.get("id")?.value) {
        const newData: Country = this.dataForm.value;
        this.addressService.updateCountry(newData).subscribe({
          next: (res) => {
            if (res.success) {
              this.translate.get('country sucessfully updated').subscribe((res: string) => {
                this.successAddMessage = res;
              });
              this.closeModal();
              successToast(this.successUpdateMessage);
              this.refreshData()
            }
          },
          error: (err) => {},
        });

      } else {
        const newData: Country = this.dataForm.value;
        newData.isActive = true;
        this.addressService.addCountry(newData).subscribe({
          next: (res) => {
            if (res.success) {
              this.translate.get('country sucessfully added').subscribe((res: string) => {
                this.successAddMessage = res;
              });
              this.closeModal();
              successToast(this.successAddMessage);
              this.refreshData()
            }
          },
          error: (err) => {},
        });
      }
    }
    // setTimeout(() => {
    //   this.dataForm.reset();
    // }, 2000);
    this.submitted = true;
  }

  closeModal() {
    this.modalService.dismissAll();
  }

  /**
   * Open Edit modal
   * @param content modal content
   */
  editDataGet(id: any, content: any) {
    this.submitted = false;
    this.modalService.open(content, { size: "md", centered: true });
    var modelTitle = document.querySelector(".modal-title") as HTMLAreaElement;
    modelTitle.innerHTML = "Edit Contact";
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    updateBtn.innerHTML = "Update";
    this.isEditing = true;
    this.econtent = this.countries[id];
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    this.dataForm.controls["countryCode"].setValue(this.econtent.countryCode);
    this.dataForm.controls["nationalityName"].setValue(
      this.econtent.nationalityName
    );
    this.dataForm.controls["localNationalityName"].setValue(
      this.econtent.localNationalityName
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.id);
    this.dataForm.controls["id"].setValue(this.econtent.id);
    this.dataForm.controls["isActive"].setValue(this.econtent.isActive);
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
        "createdById"
      ],
    };
    new ngxCsv(this.allcountries, "Countries", orders);
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
    this.allcountries = this.service.onSort(column, this.allcountries);
    this.countries = this.service.changePage(this.allcountries)
  }
}
