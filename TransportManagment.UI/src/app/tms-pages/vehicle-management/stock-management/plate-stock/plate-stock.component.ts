import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
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
  searchTerm: any;
  searchResults: any;

  allPlates?:any;
  plates?: any;
  selectedPlateTypelId: any;

  selectedFilters: { [key: string]: any } = {};
  filters = {
    plateType: null,
    region: null,
    // Declare properties for other filters
  };
  
  allPlateStocks?: any;
  plateStocks?: any;
  metaData: any;

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: Pagination1Service,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
    public plateStocService: PlateStockService,
    public plateTypeService:PlateTypeService

  ) { }
  ngOnInit(): void {
    this.currentUser = this.tokenStorageService.getCurrentUser();
    this.refreshData()
    /**
     * Form Validation
     */
    // this.dataForm = this.formBuilder.group({
    //   id: [""],
    //   fileName: ["", [Validators.required]],
    //   fileExtentions: ["", [Validators.required]],
    //   isPermanentRequired: [false],
    //   isTemporaryRequired:[false],
    //   createdById: [this.currentUser?.userId, [Validators.required]],
    //   isActive:[true]
    // });
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
    this.plateStocService.getAllPlateStock(pageNumber).subscribe({
      
      next: (res) => {
        if (res) {
          this.plateStocks = res.data || [];
          //this.plateStocks = res.data
          this.metaData = res.metaData;
          this.allPlateStocks = cloneDeep(res);
          

          //this.service.pageSize = this.metaData.pageSize;
          //this.service.page = this.metaData.currentPage;
          //this.service.totalItemss = this.metaData.totalCount;

          //this.plateStocks = this.service.changePage(this.allPlateStocks)
        } else {
          this.plateStocks = [];
          this.metaData = null;
          this.allPlateStocks = null;
        }
      },
      error: (err) => {

      },
    });
    this.plateTypeService.getAllPlateType().subscribe({
      next: (res) => {
        if (res) 
          {
            this.plates = res
            this.allPlates = cloneDeep(res);
            //this.plates = this.service.changePage(this.allPlates)
            //console.log(this.allPlates)
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

}
