import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ngxCsv } from 'ngx-csv';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

@Component({
  selector: 'app-vehicle-type',
  //standalone: true,
  //imports: [CommonModule],
  templateUrl: './vehicle-type.component.html',
  styleUrl: './vehicle-type.component.scss'
})
export class VehicleTypeComponent implements OnInit{
  breadCrumbItems!: Array<{}>;
  submitted = false;
  isEditing:Boolean = false;
  allVehicleTypes?:any;
  VehicleTypes?:any;
  searchTerm: any;
  searchResults: any;

  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;

  constructor(
    private modalService: NgbModal,
    public service: PaginationService,
    private tokenStorageService: TokenStorageService,
    private formBuilder: UntypedFormBuilder,
  ) {}

  ngOnInit(): void {
    /**
     * BreadCrumb
     */
    this.currentUser = this.tokenStorageService.getCurrentUser();
    //this.refreshData()

    this.breadCrumbItems = [
      { label: "Vehicle" },
      { label: "Vehicle Type", active: true },
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
  }

  openModal(content: any) {
    this.submitted = false;
    this.isEditing = false;
    //this.dataForm.reset();
    //this.dataForm.controls["createdById"].setValue(this.currentUser?.id);
    this.modalService.open(content, { size: "md", centered: true });
  }
  csvFileExport() {
    var orders = {
      fieldSeparator: ",",
      quoteStrings: '"',
      decimalseparator: ".",
      showLabels: true,
      showTitle: true,
      title: "vehicle Type Data",
      useBom: true,
      noDownload: false,
      headers: [
        "name",
        "localName",
        "countryCode",
        "isActive",
        "createdById"
      ],
    };
    new ngxCsv(this.allVehicleTypes, "vehicleType", orders);
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
  //search data
  performSearch(): void {
    this.searchResults = this.allVehicleTypes.filter((item: any) => {
      return item.name.toLowerCase().includes(this.searchTerm.toLowerCase());
    });
    this.VehicleTypes = this.service.changePage(this.searchResults);
  }
  // Sort data
  onSort(column: any) {
    this.allVehicleTypes = this.service.onSort(column, this.allVehicleTypes);
    this.VehicleTypes = this.service.changePage(this.VehicleTypes)
  }

  get form() {
    return this.dataForm.controls;
  }
  saveData() {}
  // saveData() {
  //   const updatedData = this.dataForm.value;
   
  //   if (this.dataForm.valid) {
  //     if (this.dataForm.get("id")?.value) {
  //       const newData: Country = this.dataForm.value;
  //       this.addressService.updateCountry(newData).subscribe({
  //         next: (res) => {
  //           if (res.success) {
  //             this.translate.get('country sucessfully updated').subscribe((res: string) => {
  //               this.successAddMessage = res;
  //             });
  //             this.closeModal();
  //             successToast(this.successUpdateMessage);
  //             this.refreshData()
  //           }
  //         },
  //         error: (err) => {},
  //       });

  //     } else {
  //       const newData: Country = this.dataForm.value;
  //       newData.isActive = true;
  //       this.addressService.addCountry(newData).subscribe({
  //         next: (res) => {
  //           if (res.success) {
  //             this.translate.get('country sucessfully added').subscribe((res: string) => {
  //               this.successAddMessage = res;
  //             });
  //             this.closeModal();
  //             successToast(this.successAddMessage);
  //             this.refreshData()
  //           }
  //         },
  //         error: (err) => {},
  //       });
  //     }
  //   }
  //   // setTimeout(() => {
  //   //   this.dataForm.reset();
  //   // }, 2000);
  //   this.submitted = true;
  // }
  // refreshData(){
  //   this.addressService.getAllCountries().subscribe({
  //     next: (res) => {
  //       if (res) 
  //         {
  //           this.countries = res
  //           this.allcountries = cloneDeep(res);
  //           this.countries = this.service.changePage(this.allcountries)
  //         }
  //     },
  //     error: (err) => {
        
  //     },
  //   });
  // }
}
