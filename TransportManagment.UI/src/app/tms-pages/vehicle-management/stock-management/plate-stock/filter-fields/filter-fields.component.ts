import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { cloneDeep } from 'lodash';
import { PlateTypeService } from 'src/app/core/services/vehicle-config-services/plate-type.service';
import { AddressService } from 'src/app/core/services/address.service';
import { fetchCrmContactData } from 'src/app/store/CRM/crm_action';
import { selectCRMLoading } from 'src/app/store/CRM/crm_selector';
import { UserView } from 'src/app/model/user';
import { Store } from '@ngrx/store';
import { TokenStorageService } from 'src/app/core/services/token-storage.service';
import { RootReducerState } from 'src/app/store';
import { VehicleLookupService } from 'src/app/core/services/vehicle-config-services/vehicle-lookup.service';

@Component({
  selector: 'app-filter-fields',
  templateUrl: './filter-fields.component.html',
  styleUrl: './filter-fields.component.scss'
})
export class FilterFieldsComponent implements OnInit {

  criteria: { columnName: string, filterValue: string }[] = [];
  @Output() criteriaSaved = new EventEmitter();

  currentUser!: UserView | null;
  allPlates?: any;
  plates?: any;
  selectedPlateTypelId: any;
  
  plateStockCriteria: plateStockCriteria = new plateStockCriteria()

  allists?: any;
  lists?: any;
  allZone?: any;

  frontPlateSize: number = 2;
  allFrontPlate?: any;
  frontPlate?: any;
  allBackPlate?: any;

  plateTypeId: number | null = null;

  regionId: number | null = null;

  frontPlateSizeId: number | null = null;
  backPlateSizeId: number | null = null;
  zoneId: number | null = null;

  statusOptions = [
    { label: 'Active', value: 'true' },
    { label: 'Inactive', value: 'false' },
  ];
  selectedStatus: string | null = null;

  plateTypeNames: string[] = [];
  plateTypeNameIdMap: { [name: string]: number } = {};

  constructor(
    public plateTypeService: PlateTypeService,
    private addressService: AddressService,
    private tokenStorageService: TokenStorageService,
    private store: Store<{ data: RootReducerState }>,
    public vehicleLookupService: VehicleLookupService
  ) { }
  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()

    this.store.dispatch(fetchCrmContactData());
    this.store.select(selectCRMLoading).subscribe((data) => {
      if (data == false) {
        document.getElementById("elmLoader")?.classList.add("d-none");
      }
    });
  }

  saveCriteria() {
    this.criteriaSaved.emit(this.plateStockCriteria);
  }


  refreshData() {
    this.plateTypeService.getAllPlateType().subscribe({
      next: (res) => {
        if (res) {
          this.plates = res
          this.allPlates = cloneDeep(res);

          this.plateTypeNames = this.plates.map((veh: any) => veh.name);
        }
        // Populate the markNameIdMap with name-ID mapping
        this.plateTypeNameIdMap = this.allPlates.reduce((map: any, veh: any) => {
          map[veh.name] = veh.id;
          return map;
        }, {});
      },
      error: (err) => {
      },
    });
    this.addressService.getAllRegion().subscribe({
      next: (res) => {
        if (res) {
          this.lists = res
          this.allists = cloneDeep(res);
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
        }
      },
      error: (err) => {

      },
    });
    this.addressService.getAllZone().subscribe({
      next: (res) => {
        if (res) {
          //this.lists = res
          this.allZone = cloneDeep(res);
        }
      },
      error: (err) => {

      },
    });
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
