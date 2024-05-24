import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OwnerService } from 'src/app/core/services/vehicle/owner.service';
import { TranslateService } from '@ngx-translate/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { UserView } from 'src/app/model/user';

import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { successToast } from 'src/app/core/services/toast.service';
import { ToastService } from 'src/app/account/login/toast-service';
import { Subject, debounceTime, distinctUntilChanged } from 'rxjs';
import { cloneDeep } from 'lodash';
import { Pagination1Service } from 'src/app/core/services/pagination1.service';
import { AddressService } from 'src/app/core/services/address.service';



@Component({
  selector: 'app-owner',
  templateUrl: './owner.component.html',
  styleUrl: './owner.component.scss'
})
export class OwnerComponent implements OnInit {
  submitted = false;
  submitted1 = false;
  currentUser!: UserView | null;
  ownerForm!: UntypedFormGroup;
  searchForm!: UntypedFormGroup;

  allOwners!: PaginatedResponse<OwnerGetDto>;
  owners!: OwnerGetDto[];
  //owner?: OwnerPostDto;
  metaData!: MetaData;
  pageSizeOptions = [
    { label: '10', value: 10 },
    { label: '15', value: 15 },
    { label: '20', value: 20 },
    { label: '25', value: 25 },
    { label: '3000', value: 3000 },
  ];
  selectedPageSize = this.pageSizeOptions[0].value;

  searchDropDownItem = [
    { name: "First Name", code: "firstname" },
    { name: "Last Name", code: "lastname" },
    { name: "Middle Name", code: "middlename" },
    { name: "Owner Number", code: "ownernumber" },
    { name: "Phone Number", code: "phonenumber" },
  ];
  search: string = "";

  genderEnum = [
    { name: 'Male', code: 0 },
    { name: 'Female', code: 1 }
  ]
  ownerGroupEnum = [
    { name: 'Private Owner', code: 0 },
    { name: 'Organization', code: 1 },
    { name: 'Government', code: 2 }
  ]



  searchTermSubject = new Subject<string>();
  searchTerm = '';

  criteria: { columnName: string, filterValue: string }[] = [];


  breadCrumbItems = [
    { label: "VRMS" },
    { label: "Owner", active: true },
  ];
  paginationMaxSize = 10;

  allZones?: any;
  zones?: any;
  zoneNames: string[] = [];
  selectedZone: { id: number; name: string } | null = null;

  woredas?: any;
  allWoredas?: any;
  woredaNames: string[] = [];
  selectedWoreda: { id: number; name: string } | null = null;

  editOwnerText = "Edit Owner";
  updateText = "Update";
  isEditing: Boolean = false;
  econtent?: any;

  selectedSearchType!: string;

  constructor(private ownerService: OwnerService,
    public translate: TranslateService,
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,

    public toastService: ToastService,
    public service: Pagination1Service,
    private addressService: AddressService,
  ) {
    // this.searchTermSubject
    //   .pipe(
    //     debounceTime(500), // Adjust the debounce time as needed
    //     distinctUntilChanged()
    //   )
    //   .subscribe(term => {
    //     this.searchTerm = term;
    //     this.refreshData();
    //   });
  }

  ngOnInit(): void {
    this.refreshData();
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.ownerForm = this.formBuilder.group({
      ownerGroup: ["", Validators.required],
      firstName: ["", Validators.required],
      middleName: ["", Validators.required],
      lastName: ["", Validators.required],
      amharicFirstName: ["", Validators.required],
      amharicMiddleName: ["", Validators.required],
      amharicLastName: ["", Validators.required],
      gender: ["", Validators.required],
      zoneId: ["", Validators.required],
      woredaId: [""],
      town: [""],
      houseNo: ["", Validators.required],
      phoneNumber: ["", Validators.required],
      secondaryPhoneNumber: [""],
      idNumber: ["", Validators.required],
      poBox: [""],
      createdById: [this.currentUser?.userId, [Validators.required]],
      serviceZoneId: [this.currentUser?.userTypeId, [Validators.required]],
    });
    this.searchForm = this.formBuilder.group({
      searchType: ["", Validators.required],
      search: ["", Validators.required],
    });

  }

  submitSearch() {
    this.submitted1 = true;
    const selectedSearchType = this.searchForm.get('searchType')?.value;
    const searchValue = this.searchForm.get('search')?.value;

    if (selectedSearchType && searchValue) {
      const columnName = this.searchDropDownItem.find(item => item.code === selectedSearchType)?.code;
      const filterValue = searchValue;

      if (columnName && filterValue) {
        this.criteria.push({ columnName, filterValue });
        console.log(this.criteria)

        //this.searchForm.reset();
      }
    }

    this.refreshData();
  }
  changePage() {
    this.owners = this.service.changePage(this.allOwners, this.metaData);
    this.refreshData();
  }
  refreshData() {
    const pageNumber = this.metaData ? this.metaData.currentPage : 1;
    const pageSize = this.selectedPageSize;

    this.ownerService.getAllOwner(pageNumber, pageSize, this.criteria).subscribe({

      next: (res) => {
        if (res) {
          this.owners = res.data || [];
          this.metaData = res.metaData;
          this.allOwners = cloneDeep(res);
          console.log(this.owners)
          console.log(this.allOwners)

        } else {
          this.owners = [];
          //this.metaData = null;
          //this.allOwners = null;
        }
      },
      error: (err) => {

      },
    });
    this.addressService.getAllZone().subscribe({
      next: (res) => {
        if (res) {
          this.zones = res
          this.allZones = cloneDeep(res);
          this.zoneNames = this.allZones.map((veh: any) => ({
            id: veh.id,
            name: veh.name,
          }));
        }
      },
      error: (err) => {

      },
    });
    this.addressService.getAllWoreda().subscribe({
      next: (res) => {
        if (res) {
          this.woredas = res
          this.allWoredas = cloneDeep(res);
          this.woredaNames = this.allWoredas.map((veh: any) => ({
            id: veh.id,
            name: veh.name,
          }));
        }
      },
      error: (err) => {

      },
    });

  }
  onSubmit() {
    if (this.ownerForm.valid) {
      if (this.ownerForm.get("id")?.value) {
        console.log(this.currentUser?.userId)
        const newData: OwnerPostDto = this.ownerForm.value;
        this.ownerService.updateOwner(newData).subscribe({
          next: (res: ResponseMessage) => {
            if (res.success) {
              this.toastService.show(res.message, {
                classname: "success text-white",
                delay: 2000,
              });
              this.ownerForm.reset()
            } else {
              console.error(res.message);
            }
          },
          error: (err) => {
            console.error(err);
          },
        });

      } else {
    // this.submitted = true;
    // console.log(this.submitted);
    // if (this.ownerForm.invalid) {
    //   return; 
    // }

    //this.ownerForm.controls["createdById"].setValue(this.currentUser?.userId);
    //this.ownerForm.markAsTouched();

    if (this.ownerForm.valid) {
      const newData: OwnerPostDto = this.ownerForm.value;
      this.ownerService.addOwner(newData).subscribe({
        next: (res: ResponseMessage) => {
          if (res.success) {
            this.toastService.show(res.message, {
              classname: "success text-white",
              delay: 2000,
            });
            //this.ownerForm.reset()
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
  }
    this.submitted = true;
  }
  get f() {
    return this.ownerForm.controls;
  }
  get fo() {
    return this.searchForm.controls;
  }
  openModal(content: any) {
    this.submitted = false;
    this.ownerForm.reset();
    this.ownerForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  closeModal() {
    this.modalService.dismissAll();
  }

  editDataGet(id: any, content: any) {
    this.submitted = false;
    this.modalService.open(content, { size: "lg", centered: true });
    var modelTitle = document.querySelector(".modal-title") as HTMLAreaElement;
    this.translate.get("Edit Owner").subscribe((res: string) => {
      this.editOwnerText = res;
    });
    modelTitle.innerHTML = this.editOwnerText;
    var updateBtn = document.getElementById("add-btn") as HTMLAreaElement;
    this.translate.get("Update").subscribe((res: string) => {
      this.editOwnerText = res;
    });
    updateBtn.innerHTML = this.updateText;
    this.isEditing = true;
    this.econtent = this.owners[id];
    this.ownerForm.controls["ownerGroup"].setValue(this.econtent.ownerGroup);
    this.ownerForm.controls["firstName"].setValue(this.econtent.firstName);
    this.ownerForm.controls["middleName"].setValue(this.econtent.middleName);
    this.ownerForm.controls["lastName"].setValue(this.econtent.lastName);
    this.ownerForm.controls["amharicFirstName"].setValue(this.econtent.firstName);
    this.ownerForm.controls["amharicMiddleName"].setValue(this.econtent.middleName);
    this.ownerForm.controls["amharicLastName"].setValue(this.econtent.amharicLastName);
    this.ownerForm.controls["lastName"].setValue(this.econtent.lastName);

    this.ownerForm.controls["gender"].setValue(this.econtent.gender);
    this.ownerForm.controls["zoneId"].setValue(this.econtent.zoneId);
    this.ownerForm.controls["woredaId"].setValue(this.econtent.woredaId);

    this.ownerForm.controls["town"].setValue(this.econtent.town);
    this.ownerForm.controls["houseNo"].setValue(this.econtent.houseNo);
    this.ownerForm.controls["phoneNumber"].setValue(this.econtent.phoneNumber);

    this.ownerForm.controls["secondaryPhoneNumber"].setValue(this.econtent.town);
    this.ownerForm.controls["idNumber"].setValue(this.econtent.houseNo);
    this.ownerForm.controls["poBox"].setValue(this.econtent.phoneNumber);

    this.ownerForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.ownerForm.controls["id"].setValue(this.econtent.id);
  }
}