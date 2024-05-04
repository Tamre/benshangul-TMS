import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { VehicleManagementRoutingModule } from './vehicle-management-routing.module';
import { NgbAccordionModule, NgbDropdownModule, NgbModule, NgbNavModule, NgbPaginationModule, NgbProgressbarModule, NgbTooltipModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlatpickrModule } from 'angularx-flatpickr';
import { NgSelectModule } from '@ng-select/ng-select';
import { configurationRoutingModule } from '../configuration/configuration-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { LanguageService } from 'src/app/core/services/language.service';
import { NgPipesModule } from 'ngx-pipes';
import { TranslateModule } from '@ngx-translate/core';
import { FeatherModule } from 'angular-feather';
import { allIcons } from 'angular-feather/icons';
import { DropzoneModule } from 'ngx-dropzone-wrapper';
import { SimplebarAngularModule } from 'simplebar-angular';
import { VehicleConfigComponent } from './vehicle-config/vehicle-config.component';
import { AisorcStockTypeComponent } from './vehicle-config/plate/aisorc-stock-type/aisorc-stock-type.component';
import { BanBodyComponent } from './vehicle-config/look-ups/ban-body/ban-body.component';
import { DepreciatioCostComponent } from './vehicle-config/valuation/depreciatio-cost/depreciatio-cost.component';
import { SortByCrmPipe1 } from './sort-by.pipe';



import { PlateComponent } from './vehicle-config/plate/plate.component';
import { VehicleSettingComponent } from './vehicle-config/vehicle-setting/vehicle-setting.component';
import { LookUpsComponent } from './vehicle-config/look-ups/look-ups.component';
import { ValuationComponent } from './vehicle-config/valuation/valuation.component';
import { PlateTypeComponent } from './vehicle-config/plate/plate-type/plate-type.component';
import { DocumentTypeComponent } from './vehicle-config/document-type/document-type.component';
import { VehicleLookupsComponent } from './vehicle-config/look-ups/vehicle-lookups/vehicle-lookups.component';
import { ServiceTypeComponent } from './vehicle-config/vehicle-setting/service-type/service-type.component';
import { GeneralSettingComponent } from './vehicle-config/vehicle-setting/general-setting/general-setting.component';
import { VehicleBodyTypeComponent } from './vehicle-config/vehicle-setting/vehicle-body-type/vehicle-body-type.component';
import { VehicleModelComponent } from './vehicle-config/vehicle-setting/vehicle-model/vehicle-model.component';
import { VehicleTypeComponent } from './vehicle-config/vehicle-setting/vehicle-type/vehicle-type.component';
import { ManufactureCountryComponent } from './vehicle-config/valuation/manufacture-country/manufacture-country.component';
import { FactoryPointComponent } from './vehicle-config/valuation/factory-point/factory-point.component';
import { ServiceYearComponent } from './vehicle-config/valuation/service-year/service-year.component';
import { InitialPriceComponent } from './vehicle-config/valuation/initial-price/initial-price.component';
import { SalvageValueComponent } from './vehicle-config/valuation/salvage-value/salvage-value.component';
import { StockManagementComponent } from './stock-management/stock-management.component';
import { PlateStockComponent } from './stock-management/plate-stock/plate-stock.component';
import { FilterFieldsComponent } from './stock-management/plate-stock/filter-fields/filter-fields.component';
import { OrcStockComponent } from './stock-management/orc-stock/orc-stock.component';




@NgModule({
  declarations: [
    VehicleConfigComponent,
    SortByCrmPipe1,
    BanBodyComponent,
    DepreciatioCostComponent,
    PlateComponent,
    VehicleSettingComponent,
    LookUpsComponent,
    ValuationComponent,
    PlateTypeComponent,
    DocumentTypeComponent,
    AisorcStockTypeComponent,
    VehicleLookupsComponent,
    ServiceTypeComponent,
    GeneralSettingComponent,
    VehicleBodyTypeComponent,
    VehicleModelComponent,
    VehicleTypeComponent,
    ManufactureCountryComponent,
    FactoryPointComponent,
    ServiceYearComponent,
    InitialPriceComponent,
    SalvageValueComponent,
    StockManagementComponent,
    PlateStockComponent,
    FilterFieldsComponent,
    OrcStockComponent

  ],
  imports: [
    CommonModule,
    VehicleManagementRoutingModule,
    NgbNavModule,
    FeatherModule.pick(allIcons),
    SimplebarAngularModule,
    DropzoneModule,
    TranslateModule,
    FormsModule,
    ReactiveFormsModule,
    NgbPaginationModule,
    NgbTypeaheadModule,
    NgbTooltipModule,
    NgbDropdownModule,
    NgbAccordionModule,
    FlatpickrModule,
    NgSelectModule,
    configurationRoutingModule,
    SharedModule,
    NgbProgressbarModule,
    NgPipesModule,
    NgbModule,
    
    
  ],
  providers: [
    DatePipe,
    LanguageService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class VehicleManagementModule { }
