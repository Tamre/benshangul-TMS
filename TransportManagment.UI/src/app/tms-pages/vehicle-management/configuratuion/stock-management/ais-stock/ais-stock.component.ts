import { Component, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { TranslateService } from '@ngx-translate/core';
import { cloneDeep } from 'lodash';
import { Observable, Subject, debounceTime, distinctUntilChanged, map, of } from 'rxjs';
import { AddressService } from 'src/app/core/services/address.service';
import { Pagination1Service } from 'src/app/core/services/pagination1.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

import { UserView } from 'src/app/model/user';

import { successToast } from 'src/app/core/services/toast.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { AisStockPostDto } from 'src/app/model/stock-management/ais-stock';
import Swal from 'sweetalert2';
import { StockManagementService } from 'src/app/core/services/Vehicle-services/stock-management.service';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';

@Component({
  selector: 'app-ais-stock',
  templateUrl: './ais-stock.component.html',
  styleUrl: './ais-stock.component.scss'
})
export class AisStockComponent {
  submitted = false;
  isEditing: Boolean = false;
  dataForm!: UntypedFormGroup;
  dataForm1!: UntypedFormGroup;
  currentUser!: UserView | null;
  masterSelected!: boolean;

  aisStocks?:any;
  allAisStocks?:any;
  metaData: any;


  criteria: { columnName: string, filterValue: string }[] = [];
  statusOptions = [
    { label: 'Active', value: 'true' },
    { label: 'Inactive', value: 'false' },
  ];

  pageSizeOptions = [
    { label: '10', value: 10 },
    { label: '15', value: 15 },
    { label: '20', value: 20 },
    { label: '25', value: 25 },
    { label: '30', value: 30 },
  ];
  selectedPageSize = this.pageSizeOptions[0].value;

  selectedAisStockIds: string[] = [];

  allStocks?:any;
  stocks?: any;
  aisStock?: any;
  stocksNames: string[] = [];

  allRegion?: any;
  regions?: any;
  regionNames: string[] = [];

  allZone?:any;
  zones?:any;
  zoneNames: string[] = [];
  selectedZone: { id: number; name: string } | null = null;

  searchTermSubject = new Subject<string>();
  searchTerm = '';

  aisStockCriteria: aisStockCriteria = new aisStockCriteria()

  aisTypeNames: string[] = [];
  selectedAisType: { id: number; name: string } | null = null;

  selectedRegion: { id: number; name: string } | null = null;
  successAddMessage: string = "";

  paginationMaxSize = 10;
  
  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: Pagination1Service,
    public translate: TranslateService,

    public stockManagementService: StockManagementService,
    public vehicleConfigService: VehicleConfigService,
    private addressService: AddressService

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
    this.getDatasforAddAisStock()
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      stockTypeId: ["", [Validators.required]],
      regionId: ["", [Validators.required]],
      toZoneId: ["", [Validators.required]],

      fromAISNo: ["", [Validators.required], this.patternValidator],
      toAISNo: ["", [Validators.required], this.patternValidator],
      createdById: [this.currentUser?.userId, [Validators.required]],
    });
    this.dataForm1 = this.formBuilder.group({
      zoneId: ['', Validators.required],
    });
 
  }
  patternValidator: Validators = (control: AbstractControl): Observable<ValidationErrors | null> => {
    const pattern = /^-?\d+$/;
    const value = control.value;
  
    return of(pattern.test(value) ? null : { pattern: true }).pipe(
      map((error: ValidationErrors | null) => error)
    );
  };
  checkUncheckAll(ev: any, id: string | null) {
    const isChecked = ev.target.checked;
  
    if (id === null) {
      // Handle the case when the header checkbox is checked or unchecked
      this.aisStocks.forEach((x: { state: any }) => (x.state = isChecked));
      this.selectedAisStockIds = isChecked
        ? this.aisStocks.map((data:any) => data.id)
        : [];
    } else {
      // Handle the case when an individual checkbox is checked or unchecked
      if (isChecked) {
        this.selectedAisStockIds.push(id);
      } else {
        this.selectedAisStockIds = this.selectedAisStockIds.filter(
          (stockId) => stockId !== id
        );
      }
    }
  }
  refreshData() {
    const pageNumber = this.metaData ? this.metaData.currentPage : 1;
    //const pageSize = this.metaData ? this.metaData.pageSize : 10;
    const pageSize = this.selectedPageSize;

    this.stockManagementService.getAllAisStock(pageNumber, pageSize, this.criteria, this.searchTerm).subscribe({

      next: (res) => {
        if (res) {
          this.aisStocks = res.data || [];
          this.metaData = res.metaData;
          this.allAisStocks = cloneDeep(res);
          console.log('allaisstock',this.allAisStocks);
          console.log('aisstock',this.aisStocks);

        } else {
          this.aisStocks = [];
          this.metaData = null;
          this.allAisStocks = null;
        }
      },
      error: (err) => {

      },
    });}
  getDatasforAddAisStock() {
    this.vehicleConfigService.getAllStockType().subscribe({
      next: (res) => {
        if (res) 
          {
            this.stocks = res
            this.allStocks = cloneDeep(res);
            this.aisStock = this.allStocks.filter((stock: { category: string }) => stock.category === 'AIS');
            // this.stocksNames = this.orcStock.map((veh: any) => ({
            //   id: veh.id,
            //   name: veh.name,
            // }));
            // this.stocksNames = orcStock.map((stock: any) => stock.name);
            this.stocksNames = this.aisStock.map((stock: any) => ({ id: stock.id, name: stock.name }));
            
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
  openModal(content: any) {
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  openModal1(content1: any) {
    if (this.selectedAisStockIds.length === 0) {
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
  // onStockTypeChange(event: any) {
  //   const stockTypeId = event?.id || null;

  //   if (stockTypeId !== null) {
  //     this.criteria = [{ columnName: 'ais_type', filterValue: stockTypeId.toString() }];
  //   }
  // }
  // onStatusChange(event: any) {
  //   const selectedItem = event;
  //   this.selectedStatus = selectedItem ? selectedItem.value : null;
  
  //   if (this.selectedStatus !== null) {
  //     const existingCriteria = this.criteria.filter(c => c.columnName !== 'status');
  //     this.criteria = [
  //       ...existingCriteria,
  //       { columnName: 'status', filterValue: this.selectedStatus }
  //     ];
  //   }
  // }
  // onZoneChange(event: any) {
  //   const zoneId = event?.id || null;

  //   if (zoneId !== null) {
  //     const existingCriteria = this.criteria.filter(c => c.columnName !== 'zone');
  //     this.criteria = [...existingCriteria, { columnName: 'zone', filterValue: zoneId.toString() }];
  //   }
  // }
  changePage() {
    this.aisStocks = this.service.changePage(this.allAisStocks, this.metaData);
    this.refreshData();
  }
  saveCriteria() {
    this.criteria = Object.entries(this.aisStockCriteria)
    .filter(([key, value]) => value !== undefined && value !== null)
    .map(([columnName, filterValue]) => ({ columnName, filterValue: filterValue.toString() }));
    this.refreshData();

  }
  saveData() {
    const newData: AisStockPostDto = this.dataForm.value;
    this.stockManagementService.addAisStock(newData).subscribe({
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
  get form() {
    return this.dataForm.controls;
  }
  transferData(){
    this.submitted = true;

    if (this.dataForm1.valid) {
      const selectedZoneId = this.dataForm1.controls['zoneId'].value;

      // Call the service method to transfer the plate stocks
      this.stockManagementService.transferAisStock({
        aisStockIds: this.selectedAisStockIds,
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

  closeModal() {
    this.modalService.dismissAll();
  }
  closeModal1() {
    this.modalService.dismissAll();
  }

}
export class aisStockCriteria {
  ais_type!: string
  zone!: string
  status!: string
}
