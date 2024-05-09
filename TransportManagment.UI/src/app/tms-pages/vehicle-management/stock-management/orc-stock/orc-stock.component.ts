import { Component, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { Observable, Subject, debounceTime, distinctUntilChanged, map, of } from 'rxjs';
import { AddressService } from 'src/app/core/services/address.service';
import { Pagination1Service } from 'src/app/core/services/pagination1.service';
import { PlateStockService } from 'src/app/core/services/stock-management/plate-stock.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { PlateTypeService } from 'src/app/core/services/vehicle-config-services/plate-type.service';
import { VehicleLookupService } from 'src/app/core/services/vehicle-config-services/vehicle-lookup.service';
import { RootReducerState } from 'src/app/store';
import { StockTypeService } from 'src/app/core/services/vehicle-config-services/stock-type.service';
import { cloneDeep } from 'lodash';
import { OrcStockPostDto } from 'src/app/model/stock-management/orc-stock';
import { OrcStockService } from 'src/app/core/services/stock-management/orc-stock.service';
import { successToast } from 'src/app/core/services/toast.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-orc-stock',
  templateUrl: './orc-stock.component.html',
  styleUrl: './orc-stock.component.scss'
})
export class OrcStockComponent {
  submitted = false;
  isEditing: Boolean = false;
  dataForm!: UntypedFormGroup;
  dataForm1!: UntypedFormGroup;
  currentUser!: UserView | null;
  masterSelected!: boolean;

  searchTermSubject = new Subject<string>();
  searchTerm = '';

  allStocks?:any;
  stocks?: any;
  orcStock?: any;
  stocksNames: string[] = [];

  orcStocks?:any;
  allOrcStocks?:any;
  metaData: any;

  allRegion?: any;
  regions?: any;
  regionNames: string[] = [];

  allZone?:any;
  zones?:any;

  orcStockCriteria: orcStockCriteria = new orcStockCriteria()
  criteria: { columnName: string, filterValue: string }[] = [];
  statusOptions = [
    { label: 'Active', value: 'true' },
    { label: 'Inactive', value: 'false' },
  ];
  //selectedStatus: string | null = null;
  //criteriaSaved = new EventEmitter<{ columnName: string, filterValue: string }[]>();

  pageSizeOptions = [
    { label: '10', value: 10 },
    { label: '15', value: 15 },
    { label: '20', value: 20 },
    { label: '25', value: 25 },
    { label: '30', value: 30 },
  ];
  selectedPageSize = this.pageSizeOptions[0].value;

  selectedOrcStockIds: string[] = [];

  orcTypeNames: string[] = [];
  selectedOrcType: { id: number; name: string } | null = null;

  selectedRegion: { id: number; name: string } | null = null;
  successAddMessage: string = "";

  zoneNames: string[] = [];
  selectedZone: { id: number; name: string } | null = null;

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: Pagination1Service,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
    public plateStocService: PlateStockService,
    public plateTypeService: PlateTypeService,
    private addressService: AddressService,
    public vehicleLookupService: VehicleLookupService,
    public stockTypeService: StockTypeService,
    public orcStocService:OrcStockService

  ) {
    this.searchTermSubject
      .pipe(
        debounceTime(500), // Adjust the debounce time as needed
        distinctUntilChanged()
      )
      .subscribe(term => {
        this.searchTerm = term;
        this.refreshData();
      });
  }
  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()
    this.getDatasforAddOrcStock()
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      stockTypeId: ["", [Validators.required]],
      regionId: ["", [Validators.required]],
      toZoneId: ["", [Validators.required]],

      fromORCNo: ["", [Validators.required], this.patternValidator],
      toORCNo: ["", [Validators.required], this.patternValidator],
      createdById: [this.currentUser?.userId, [Validators.required]],
    });
    this.dataForm1 = this.formBuilder.group({
      zoneId: ['', Validators.required],
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
  
  refreshData() {
    const pageNumber = this.metaData ? this.metaData.currentPage : 1;
    //const pageSize = this.metaData ? this.metaData.pageSize : 10;
    const pageSize =this.selectedPageSize;

    this.orcStocService.getAllOrcStock(pageNumber, pageSize, this.criteria, this.searchTerm).subscribe({

      next: (res) => {
        if (res) {
          this.orcStocks = res.data || [];
          this.metaData = res.metaData;
          this.allOrcStocks = cloneDeep(res);
          console.log('allorcstock',this.allOrcStocks);
          console.log('orcstock',this.orcStocks);

        } else {
          this.orcStocks = [];
          this.metaData = null;
          this.allOrcStocks = null;
        }
      },
      error: (err) => {

      },
    });}
  patternValidator: ValidatorFn = (control: AbstractControl): Observable<ValidationErrors | null> => {
    const pattern = /^-?\d+$/;
    const value = control.value;
  
    return of(pattern.test(value) ? null : { pattern: true }).pipe(
      map((error: ValidationErrors | null) => error)
    );
  };
  openModal(content: any) {
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  openModal1(content1: any) {
    if (this.selectedOrcStockIds.length === 0) {
      Swal.fire({ text: 'Please select at least one checkbox', confirmButtonColor: '#299cdb', });
      return;
    }
  
    this.dataForm1.reset();
    this.modalService.open(content1, {
      size: "md",
      centered: true,
      ariaLabelledBy: 'modal-basic-title'
    });
  }
  getDatasforAddOrcStock() {
    this.stockTypeService.getAllStockType().subscribe({
      next: (res) => {
        if (res) 
          {
            this.stocks = res
            this.allStocks = cloneDeep(res);
            this.orcStock = this.allStocks.filter((stock: { category: string }) => stock.category === 'ORC');
            this.stocksNames = this.orcStock.map((stock: any) => ({ id: stock.id, name: stock.name }));
            
          }
      },
      error: (err) => { 
      },
    });
    this.addressService.getAllRegion().subscribe({
      next: (res) => {
        if (res) {
          this.regions = res
          this.allRegion = cloneDeep(res);
          this.regionNames = this.allRegion.map((veh: any) => ({
            id: veh.id,
            name: veh.name,
          }));
        }
      },
      error: (err) => {

      },
    });
    this.addressService.getAllZone().subscribe({
      next: (res) => {
        if (res) {
          this.zones=res
          this.allZone = cloneDeep(res);
          this.zoneNames = this.allZone.map((veh: any) => ({
            id: veh.id,
            name: veh.name,
          }));
        }
      },
      error: (err) => {

      },
    });
    
  }
  
  saveCriteria() {
    //this.criteriaSaved.emit(this.criteria);
    this.criteria = Object.entries(this.orcStockCriteria)
    .filter(([key, value]) => value !== undefined && value !== null)
    .map(([columnName, filterValue]) => ({ columnName, filterValue: filterValue.toString() }));
    this.refreshData();
  }

  checkUncheckAll(ev: any, id: string | null) {
    const isChecked = ev.target.checked;
  
    if (id === null) {
      // Handle the case when the header checkbox is checked or unchecked
      this.orcStocks.forEach((x: { state: any }) => (x.state = isChecked));
      this.selectedOrcStockIds = isChecked
        ? this.orcStocks.map((data:any) => data.id)
        : [];
    } else {
      // Handle the case when an individual checkbox is checked or unchecked
      if (isChecked) {
        this.selectedOrcStockIds.push(id);
      } else {
        this.selectedOrcStockIds = this.selectedOrcStockIds.filter(
          (stockId) => stockId !== id
        );
      }
    }
  }
  changePage() {
    this.orcStocks = this.service.changePage(this.allOrcStocks, this.metaData);
    this.refreshData();
  }
  saveData() {
    const newData: OrcStockPostDto = this.dataForm.value;
    //newData.isActive = true;
    this.orcStocService.addOrcStock(newData).subscribe({
      next: (res: ResponseMessage) => {
        if (res.success) {
          this.successAddMessage = res.message;
          this.closeModal();
          successToast(this.successAddMessage);
          this.refreshData()
        } else {
          console.error(res.message);
        }

      },
      error: (err) => {
        console.error(err);
      },
    });
    this.submitted = true;
  }
  transferData(){
    this.submitted = true;

    if (this.dataForm1.valid) {
      const selectedZoneId = this.dataForm1.controls['zoneId'].value;

      // Call the service method to transfer the plate stocks
      this.orcStocService.transferOrcStock({
        orcStockIds: this.selectedOrcStockIds,
        toZoneId: selectedZoneId
      }).subscribe(
        (response) => {
          this.successAddMessage = response.message;
          this.closeModal();
          successToast(this.successAddMessage);
          // Handle the successful response
          console.log(response);
          // Close the modal or perform any other necessary actions
          this.modalService.dismissAll();
        },
        (error) => {
          // Handle the error
          console.error(error);
        }
      );
    }
  }
  /**
   * Form data get
   */
  get form() {
    return this.dataForm.controls;
  }

  closeModal() {
    this.modalService.dismissAll();
  }
  closeModal1() {
    this.modalService.dismissAll();
  }
}
export class orcStockCriteria {
  orc_type!: string
  zone!: string
  status!: string
}