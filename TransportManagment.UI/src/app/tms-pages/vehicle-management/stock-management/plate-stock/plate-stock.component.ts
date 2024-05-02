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

  
  allPlateStocks?: any;
  plateStocks?: any;
  metaData: any;

  constructor(
    private formBuilder: UntypedFormBuilder,
    private tokenStorageService: TokenStorageService,
    private modalService: NgbModal,
    public service: PaginationService,
    public translate: TranslateService,
    private store: Store<{ data: RootReducerState }>,
    public plateStocService: PlateStockService

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
    debugger
    this.plateStocService.getAllPlateStock().subscribe({
      next: (res) => {
        if (res) {
          this.plateStocks = res.data
          this.metaData = res.metaData;
          this.allPlateStocks = cloneDeep(res);
          

          this.service.pageSize = this.metaData.pageSize;
          this.service.page = this.metaData.currentPage;
          //this.service.totalItemss = this.metaData.totalCount;

          //this.plateStocks = this.service.changePage(this.allPlateStocks)
          console.log("ps",this.plateStocks)
          console.log("as",this.allPlateStocks)
        }
      },
      error: (err) => {

      },
    });
  }

  

  changePage() {
    this.plateStocks = this.service.changePage(this.allPlateStocks);
  }

}
