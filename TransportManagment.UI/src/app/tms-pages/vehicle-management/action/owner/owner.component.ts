import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OwnerService } from 'src/app/core/services/vehicle/owner.service';
import { TranslateService } from '@ngx-translate/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { UserView } from 'src/app/model/user';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { RootReducerState } from 'src/app/store';
import { Store } from '@ngrx/store';
import { MetaData, OwnerPostDto } from 'src/app/model/vehicle/owner';
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

  allOwners?: any;
  owners?: any;
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

  genderEnum= [
    { name: 'Male', code: 'Male' },
    { name: 'Female', code: 'Female' }
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

  constructor(private ownerService: OwnerService,
    public translate: TranslateService,
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    private store: Store<{ data: RootReducerState }>,
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
      houseNo: ["",Validators.required],
      phoneNumber: ["",Validators.required],
      secondaryPhoneNumber: [""],
      idNumber: [""],
      poBox: [""],
      createdById: [this.currentUser?.userId, [Validators.required]],
    });
    this.searchForm = this.formBuilder.group({
      searchType: ["", Validators.required],
      search: ["", Validators.required],
    });
    this.store.dispatch(fetchCrmContactData());
    this.store.select(selectCRMLoading).subscribe((data) => {
      if (data == false) {
        document.getElementById("elmLoader")?.classList.add("d-none");
      }
    });
  }
  submitSearch() {
    this.submitted1=true;
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

        } else {
          this.owners = [];
          //this.metaData = null;
          this.allOwners = null;
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
        if (res) 
          {
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
          this.ownerForm.reset()
        } else {
          console.error(res.message);
        }

      },
      error: (err) => {
        console.error(err);
      },
    });}
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

}