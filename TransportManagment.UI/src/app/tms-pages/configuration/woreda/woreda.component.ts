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



// Sweet Alert
import Swal from "sweetalert2";



import { cloneDeep } from "lodash";
import { PaginationService } from "src/app/core/services/pagination.service";
import { AddressService } from "src/app/core/services/address.service";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { Country } from "src/app/model/address/country";
import { UserView } from "src/app/model/user";
import { TranslateService } from "@ngx-translate/core";
import { successToast } from "src/app/core/services/toast.service";
import { Region } from "src/app/model/address/region";
import { Zone } from "src/app/model/address/zone";
import { Woreda } from "src/app/model/address/woreda";

@Component({
  selector: "app-woreda",
  templateUrl: "./woreda.component.html",
  styleUrls: ["./woreda.component.scss"],
})

/**
 * Contacts Component
 */
export class WoredaComponent implements OnInit {
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

  allcontacts: any;
  searchTerm: any;
  searchResults: any;
  allists?:any;
  zones?:any;
  lists?: any;
  currentUser!: UserView | null;
  isEditing:Boolean = false;
  successAddMessage = "country successfully added"; 
  successUpdateMessage = "country successfully updated";
  editCountryText = "Edit Country";
  updateText = "Update";
  createField?:any;
 
  constructor(
    private modalService: NgbModal,
    public service: PaginationService,
    private formBuilder: UntypedFormBuilder,
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
      { label: "zones", active: true },
    ];




    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      id: [""],
      zoneName:[""],
      zoneId: ["", [Validators.required]],
      name: ["", [Validators.required]],
      localName: ["", [Validators.required]],
      code: ["", [Validators.required]],
      localCode: ["", [Validators.required]],  
      createdById: [this.currentUser?.userId, [Validators.required]],
      isActive:[true]
    });


   
  }

  refreshData(){
    this.addressService.getAllWoreda().subscribe({
      next: (res) => {
        if (res) 
          {
            this.lists = res
            this.allists = cloneDeep(res);
            this.lists = this.service.changePage(this.allists)
          }
      },
      error: (err) => {
        
      },
    });
    this.addressService.getAllZone().subscribe({
      next: (res) => {
        if (res) 
          {
            this.zones = res
           
          }
      },
      error: (err) => {
        
      },
    });
  }

  changePage() {
    this.lists = this.service.changePage(this.allists);
  }

  // Search Data
  performSearch(): void {
    this.searchResults = this.allists.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.lists = this.service.changePage(this.searchResults);
  }

  /**
   * Open modal
   * @param content modal content
   */
 
  openModal(content: any) {
    this.submitted = false;
    this.isEditing = false;
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.dataForm.controls["zoneName"].setValue("");
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
        const newData: Woreda = this.dataForm.value;
        this.addressService.updateWoreda(newData).subscribe({
          next: (res) => {
            if (res.success) {
              
              this.closeModal();
              successToast(res.message);
              this.refreshData()
            }
          },
          error: (err) => {
            console.log(err)
          },
        });

      } else {
        const newData: Woreda = this.dataForm.value;
        newData.isActive = true;
        this.addressService.addWoreda(newData).subscribe({
          next: (res) => {
            if (res.success) {   
              this.closeModal();
              successToast(res.message);
              this.refreshData()
            }
          },
          error: (err) => {
            console.log(err)
          },
        });
      }
    }
    else{
      console.log(this.dataForm.errors)
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
    this.translate.get("Edit Woreda").subscribe((res: string) => {
      this.editCountryText = res;
    });
    modelTitle.innerHTML =this.editCountryText ;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.updateText= res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.lists[id];
    this.dataForm.controls["zoneId"].setValue(this.econtent.zoneId);
    this.dataForm.controls["name"].setValue(this.econtent.name);
    this.dataForm.controls["localName"].setValue(this.econtent.localName);
    this.dataForm.controls["code"].setValue(this.econtent.code);
    this.dataForm.controls["localCode"].setValue(
      this.econtent.localCode
    );
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
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
        "code",
        "localCode",
        "createdById"
      ],
    };
    new ngxCsv(this.allists, "lists", orders);
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
    this.allists = this.service.onSort(column, this.allists);
    this.lists = this.service.changePage(this.allists)
  }
}
