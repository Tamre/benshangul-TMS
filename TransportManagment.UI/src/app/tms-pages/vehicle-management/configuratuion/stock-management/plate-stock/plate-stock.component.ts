import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { TranslateService } from '@ngx-translate/core';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';

import { cloneDeep } from 'lodash';
import { Pagination1Service } from 'src/app/core/services/pagination1.service';
import { Observable, Subject, debounceTime, distinctUntilChanged, map, of } from 'rxjs';
import { AddressService } from 'src/app/core/services/address.service';
import { successToast } from 'src/app/core/services/toast.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { PlateStockPostDto } from 'src/app/model/stock-management/plate-stock';
import Swal from 'sweetalert2';
import { orcStockCriteria } from '../orc-stock/orc-stock.component';
import { VehicleConfigService } from 'src/app/core/services/Vehicle-services/vehicle-config.service';
import { StockManagementService } from 'src/app/core/services/Vehicle-services/stock-management.service';

@Component({
  selector: 'app-plate-stock',
  templateUrl: './plate-stock.component.html',
  styleUrl: './plate-stock.component.scss'
})
export class PlateStockComponent implements OnInit {
  //@ViewChild('content1', { static: true }) content1: TemplateRef<any>;
  submitted = false;
  isEditing: Boolean = false;
  dataForm!: UntypedFormGroup;
  dataForm1!: UntypedFormGroup;
  currentUser!: UserView | null;
  masterSelected!: boolean;

  searchResults: any;

  plateStockCriteria: plateStockCriteria = new plateStockCriteria()
  criteria: { columnName: string, filterValue: string }[] = [];

  allPlateStocks?: any;
  plateStocks?: any;
  metaData: any;

  allPlates?: any;
  plates?: any;

  allRegion?: any;
  regions?: any;

  allZones?: any;
  zones?: any;

  allists?: any;
  lists?: any;

  frontPlateSize: number = 2;
  allFrontPlate?: any;
  frontPlate?: any;
  allBackPlate?: any;

  plateDigitEnum = [
    { name: 'Three', code: 'THREE' },
    { name: 'Four', code: 'FORUR' },
    { name: 'Five', code: 'FIVE' },
    { name: 'Six', code: 'SIX' },
  ]
  statusOptions = [
    { label: 'Active', value: 'true' },
    { label: 'Inactive', value: 'false' },
  ];
  issuranceTypeEnum = [
    { name: 'Vehicle', code: 'Vehicle' },
    { name: 'Temporary', code: 'Temporary' },
    { name: 'Transit', code: 'Transit' },
    { name: 'Trailer', code: 'Trailer' },
    { name: 'Motor', code: 'Motor' },
  ]
  successAddMessage: string = "";

  searchTermSubject = new Subject<string>();
  searchTerm = '';

  //plateTypeNames: string[] = [];
  plateTypeCode: string[] = [];
  selectedPlateType: { id: number; name: string } | null = null;

  regionNames: string[] = [];
  selectedRegion: { id: number; name: string } | null = null;

  zoneNames: string[] = [];
  selectedZone: { id: number; name: string } | null = null;

  frontPlateNames: string[] = [];
  backPlateNames: string[] = [];
  selectedFrontPlateSize: { id: number; name: string } | null = null;
  selectedBackPlateSize: { id: number; name: string } | null = null;

  pageSizeOptions = [
    { label: '10', value: 10 },
    { label: '15', value: 15 },
    { label: '20', value: 20 },
    { label: '25', value: 25 },
    { label: '3000', value: 3000 },
  ];
  selectedPageSize = this.pageSizeOptions[0].value;

  selectedPlateStockIds: string[] = [];
  paginationMaxSize = 10;

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: Pagination1Service,
    public translate: TranslateService,
 
    public vehicleConfigService: VehicleConfigService,
    public stockmanagementService: StockManagementService,
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
    this.getDatasforAddPlateStock()
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      plateTypeId: ["", [Validators.required]],
      regionId: ["", [Validators.required]],
      frontPlateSizeId: ["", [Validators.required]],
      backPlateSizeId: [null],
      plateDigit: ["", [Validators.required]],
      issuanceType: ["", [Validators.required]],
      aToZ: [null],
      fromPlateNo: ["", [Validators.required], this.patternValidator],
      toPlateNo: ["", [Validators.required, this.greaterThanOrEqualValidator], this.patternValidator],
      createdById: [this.currentUser?.userId, [Validators.required]],
    });
    this.dataForm1 = this.formBuilder.group({
      zoneId: ['', Validators.required]
    });
 
  }
  checkUncheckAll(ev: any, id: string | null) {
    var isChecked = ev.target.checked;

    if (id === null) {
      // Handle the case when the header checkbox is checked or unchecked
      this.plateStocks.forEach((x: { state: any }) => (x.state = isChecked));
      this.selectedPlateStockIds = isChecked
        ? this.plateStocks.map((data: any) => data.id)
        : [];
    } else {
      // Handle the case when an individual checkbox is checked or unchecked
      if (isChecked) {
        this.selectedPlateStockIds.push(id);
      } else {
        this.selectedPlateStockIds = this.selectedPlateStockIds.filter(
          (stockId) => stockId !== id
        );
      }
    }
    
  }

  patternValidator: ValidatorFn = (control: AbstractControl): Observable<ValidationErrors | null> => {
    const pattern = /^-?\d+$/;
    const value = control.value;

    return of(pattern.test(value) ? null : { pattern: true }).pipe(
      map((error: ValidationErrors | null) => error)
    );
  };
  greaterThanOrEqualValidator: ValidatorFn = (control: AbstractControl): { [key: string]: boolean } | null => {
    if (!control.parent) {
      return null;
    }

    const fromPlateNo = control.parent.get('fromPlateNo');
    const toPlateNo = control.value;

    if (!fromPlateNo || !toPlateNo) {
      return null;
    }

    const fromPlateNoValue = parseInt(fromPlateNo.value, 10);
    const toPlateNoValue = parseInt(toPlateNo, 10);

    if (isNaN(fromPlateNoValue) || isNaN(toPlateNoValue)) {
      return null;
    }

    if (toPlateNoValue < fromPlateNoValue) {
      return { greaterThanOrEqual: true };
    }

    return null;
  };

  receiveCriteria(criteria: any[]) {
    this.criteria = Object.entries(criteria)
    .filter(([key, value]) => value !== undefined && value !== null)
    .map(([columnName, filterValue]) => ({ columnName, filterValue: filterValue.toString() }));
    this.refreshData();
  }

  getDatasforAddPlateStock() {
    this.vehicleConfigService.getAllPlateType().subscribe({
      next: (res) => {
        if (res) {
          this.plates = res
          this.allPlates = cloneDeep(res);
          this.plateTypeCode = this.allPlates.map((veh: any) => ({
            id: veh.id,
            name: veh.code,
          }));

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
    this.vehicleConfigService.getVehicleLookup(this.frontPlateSize).subscribe({
      next: (res) => {
        if (res) {
          this.frontPlate = res
          this.allFrontPlate = cloneDeep(res);
          this.allBackPlate = cloneDeep(res);
          this.frontPlateNames = this.allFrontPlate.map((veh: any) => ({
            id: veh.id,
            name: veh.name,
          }));
          this.backPlateNames = this.allBackPlate.map((veh: any) => ({
            id: veh.id,
            name: veh.name,
          }));
        }
      },
      error: (err) => {

      },
    });
  }
  refreshData() {
    const pageNumber = this.metaData ? this.metaData.currentPage : 1;
    //const pageSize = this.metaData ? this.metaData.pageSize : 10;
    const pageSize = this.selectedPageSize;

    this.stockmanagementService.getAllPlateStock(pageNumber, pageSize, this.criteria, this.searchTerm).subscribe({

      next: (res) => {
        if (res) {
          this.plateStocks = res.data || [];
          this.metaData = res.metaData;
          this.allPlateStocks = cloneDeep(res);

        } else {
          this.plateStocks = [];
          this.metaData = null;
          this.allPlateStocks = null;
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
    

  }

  saveCriteria() {
    //this.criteriaSaved.emit(this.criteria);
    this.criteria = Object.entries(this.plateStockCriteria)
    .filter(([key, value]) => value !== undefined && value !== null)
    .map(([columnName, filterValue]) => ({ columnName, filterValue: filterValue.toString() }));
    this.refreshData();
  }

  changePage() {
    this.plateStocks = this.service.changePage(this.allPlateStocks, this.metaData);
    this.refreshData();
  }
  openModal(content: any) {
    this.submitted = false;
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  openModal1(content1: any) {
    if (this.selectedPlateStockIds.length === 0) {
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
  transferData() {
    //this.submitted = true;

    if (this.dataForm1.valid) {
      const selectedZoneId = this.dataForm1.controls['zoneId'].value;

      // Call the service method to transfer the plate stocks
      this.stockmanagementService.transferPlateStock({
        plateStockIds: this.selectedPlateStockIds,
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
  deleteSelectedPlates() {
    this.stockmanagementService.deletePlateStock(this.selectedPlateStockIds)
      .subscribe(
        response => {
          console.log('Response from server:', response);
          this.closeModal();
          successToast('Delete Plate Stock Successful!!');
          this.selectedPlateStockIds = [];
          this.refreshData()
          this.modalService.dismissAll();
        },
        error => {
          console.error('Error deleting plates:', error);
        }
      );
    
  }
  confirm(content: any) {
    if (this.selectedPlateStockIds.length === 0) {
      Swal.fire({ text: 'Please select at least one checkbox', confirmButtonColor: '#299cdb', });
      return;
    }
    this.modalService.open(content, { centered: true });
  }
  saveData() {
    // this.submitted = true; // Move this line before the validation check
    // console.log('Form value:', this.dataForm.value);
    // console.log('Form status:', this.dataForm.status);
    // // Check if the form is invalid
    // if (this.dataForm.invalid) {
    //   return; // Don't proceed if the form is invalid
    // }
    this.dataForm.markAsTouched();
    const newData: PlateStockPostDto = this.dataForm.value;
    this.stockmanagementService.addPlateStock(newData).subscribe({
      next: (res: ResponseMessage) => {
        if (res.success) {
          this.successAddMessage = res.message;
          this.closeModal();
          successToast(this.successAddMessage);
          this.refreshData()
          this.dataForm.reset()
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
 
  
  closeModal() {
    this.modalService.dismissAll();
  }
  closeModal1() {
    this.modalService.dismissAll();
  }
  /**
   * Form data get
   */
  get form() {
    return this.dataForm.controls;
  }

}
export class plateStockCriteria {
  plate_code!: string
  region!: string
  front_plate_size!: string
  back_plate_size!: string
  zone!: string
  status!: string
}