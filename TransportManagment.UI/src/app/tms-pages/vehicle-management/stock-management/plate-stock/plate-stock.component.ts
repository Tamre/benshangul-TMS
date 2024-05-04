import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, UntypedFormBuilder, UntypedFormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { UserView } from 'src/app/model/user';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Store } from '@ngrx/store';
import { TranslateService } from '@ngx-translate/core';
import { PaginationService } from 'src/app/core/services/pagination.service';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { RootReducerState } from 'src/app/store';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { PlateStockService } from 'src/app/core/services/stock-management/plate-stock.service';
import { cloneDeep } from 'lodash';
import { Pagination1Service } from 'src/app/core/services/pagination1.service';
import { PlateTypeService } from 'src/app/core/services/vehicle-config-services/plate-type.service';
import { Observable, Subject, debounceTime, distinctUntilChanged, map, of } from 'rxjs';
import { AddressService } from 'src/app/core/services/address.service';
import { VehicleLookupService } from 'src/app/core/services/vehicle-config-services/vehicle-lookup.service';
import { successToast } from 'src/app/core/services/toast.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { PlateStockPostDto } from 'src/app/model/stock-management/plate-stock';

@Component({
  selector: 'app-plate-stock',
  templateUrl: './plate-stock.component.html',
  styleUrl: './plate-stock.component.scss'
})
export class PlateStockComponent implements OnInit {
  submitted = false;
  isEditing: Boolean = false;
  dataForm!: UntypedFormGroup;
  currentUser!: UserView | null;

  searchResults: any;

  criteria: { columnName: string, filterValue: string }[] = [];

  allPlateStocks?: any;
  plateStocks?: any;
  metaData: any;

  allPlates?: any;
  plates?: any;

  allRegion?: any;
  regions?: any;

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

  plateTypeNames: string[] = [];
  //selectedPlateTypeId: number | null = null;
  //plateTypeNameIdMap: { [name: string]: number } = {};
  selectedPlateType: { id: number; name: string } | null = null;

  regionNames: string[] = [];
  //regionNameIdMap: { [name: string]: number } = {};
  selectedRegion: { id: number; name: string } | null = null;

  //frontPlateNameIdMap: { [name: string]: number } = {};
  frontPlateNames: string[] = [];
  //backPlateNameIdMap: { [name: string]: number } = {};
  backPlateNames: string[] = [];
  selectedFrontPlateSize: { id: number; name: string } | null = null;
  selectedBackPlateSize: { id: number; name: string } | null = null;

  pageSizeOptions = [
    { label: '10', value: 10 },
    { label: '15', value: 15 },
    { label: '20', value: 20 },
    { label: '25', value: 25 },
    { label: '30', value: 30 },
  ];
  selectedPageSize = this.pageSizeOptions[0].value; // Initial page size

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


  ) {
    this.searchTermSubject
      .pipe(
        debounceTime(1000), // Adjust the debounce time as needed
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
    /**
     * Form Validation
     */
    this.dataForm = this.formBuilder.group({
      plateTypeId: ["", [Validators.required]],
      regionId: ["", [Validators.required]],
      frontPlateSizeId: ["", [Validators.required]],
      backPlateSizeId: [""],
      plateDigit: ["", [Validators.required]],
      issuanceType: ["", [Validators.required]],
      aToZ: [""],
      fromPlateNo: ["", [Validators.required], this.patternValidator],
      toPlateNo: ["", [Validators.required], this.patternValidator],
      createdById: [this.currentUser?.userId, [Validators.required]],
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

  patternValidator: ValidatorFn = (control: AbstractControl): Observable<ValidationErrors | null> => {
    const pattern = /^-?\d+$/;
    const value = control.value;
  
    return of(pattern.test(value) ? null : { pattern: true }).pipe(
      map((error: ValidationErrors | null) => error)
    );
  };

  receiveCriteria(criteria: { columnName: string, filterValue: string }[]) {
    this.criteria = criteria;
    this.refreshData();
  }
  
  getDatasforAddPlateStock() {
    this.plateTypeService.getAllPlateType().subscribe({
      next: (res) => {
        if (res) {
          this.plates = res
          this.allPlates = cloneDeep(res);
          this.plateTypeNames = this.allPlates.map((veh: any) => ({
            id: veh.id,
            name: veh.name,
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
    this.vehicleLookupService.getVehicleLookup(this.frontPlateSize).subscribe({
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
    const pageSize =this.selectedPageSize;

    this.plateStocService.getAllPlateStock(pageNumber, pageSize, this.criteria, this.searchTerm).subscribe({

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

  }



  changePage() {
    this.plateStocks = this.service.changePage(this.allPlateStocks, this.metaData);
    this.refreshData();
  }
  openModal(content: any) {
    this.getDatasforAddPlateStock()
    this.dataForm.reset();
    this.dataForm.controls["createdById"].setValue(this.currentUser?.userId);
    this.modalService.open(content, { size: "lg", centered: true });
  }
  saveData() {
    const newData: PlateStockPostDto = this.dataForm.value;
    //newData.isActive = true;
    this.plateStocService.addPlateStock(newData).subscribe({
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
  }
  closeModal() {
    this.modalService.dismissAll();
  }
  /**
   * Form data get
   */
  get form() {
    return this.dataForm.controls;
  }

}
