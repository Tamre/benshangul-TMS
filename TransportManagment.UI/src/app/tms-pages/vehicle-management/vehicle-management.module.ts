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


import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';

import { AisorcStockTypeComponent } from './configuratuion/vehicle-config/plate/aisorc-stock-type/aisorc-stock-type.component';
import { BanBodyComponent } from './configuratuion/vehicle-config/look-ups/ban-body/ban-body.component';
import { DepreciatioCostComponent } from './configuratuion/vehicle-config/valuation/depreciatio-cost/depreciatio-cost.component';


import { PlateComponent } from './configuratuion/vehicle-config/plate/plate.component';
import { VehicleSettingComponent } from './configuratuion/vehicle-config/vehicle-setting/vehicle-setting.component';
import { LookUpsComponent } from './configuratuion/vehicle-config/look-ups/look-ups.component';
import { ValuationComponent } from './configuratuion/vehicle-config/valuation/valuation.component';
import { PlateTypeComponent } from './configuratuion/vehicle-config/plate/plate-type/plate-type.component';
import { DocumentTypeComponent } from './configuratuion/vehicle-config/document-type/document-type.component';
import { VehicleLookupsComponent } from './configuratuion/vehicle-config/look-ups/vehicle-lookups/vehicle-lookups.component';
import { ServiceTypeComponent } from './configuratuion/vehicle-config/vehicle-setting/service-type/service-type.component';
import { GeneralSettingComponent } from './configuratuion/vehicle-config/vehicle-setting/general-setting/general-setting.component';
import { VehicleBodyTypeComponent } from './configuratuion/vehicle-config/vehicle-setting/vehicle-body-type/vehicle-body-type.component';
import { VehicleModelComponent } from './configuratuion/vehicle-config/vehicle-setting/vehicle-model/vehicle-model.component';
import { VehicleTypeComponent } from './configuratuion/vehicle-config/vehicle-setting/vehicle-type/vehicle-type.component';
import { ManufactureCountryComponent } from './configuratuion/vehicle-config/valuation/manufacture-country/manufacture-country.component';
import { FactoryPointComponent } from './configuratuion/vehicle-config/valuation/factory-point/factory-point.component';
import { ServiceYearComponent } from './configuratuion/vehicle-config/valuation/service-year/service-year.component';
import { InitialPriceComponent } from './configuratuion/vehicle-config/valuation/initial-price/initial-price.component';
import { SalvageValueComponent } from './configuratuion/vehicle-config/valuation/salvage-value/salvage-value.component';
import { StockManagementComponent } from './configuratuion/stock-management/stock-management.component';
import { PlateStockComponent } from './configuratuion/stock-management/plate-stock/plate-stock.component';
import { OrcStockComponent } from './configuratuion/stock-management/orc-stock/orc-stock.component';
import { AisStockComponent } from './configuratuion/stock-management/ais-stock/ais-stock.component';
import { VehicleConfigComponent } from './configuratuion/vehicle-config/vehicle-config.component';

import { VehicleAdd } from './action/vehicle-add/vehicle-add.component';
import { VehicleListComponent } from './action/vehicle-list/vehicle-list.component';

import { VehicleOwnersComponent } from './action/vehicle-owners/vehicle-owners.component';
import { VehicleDocumentsComponent } from './action/vehicle-documents/vehicle-documents.component';
import { AssignOwnersComponent } from './action/vehicle-owners/assign-owners/assign-owners.component';
import { VehicleDetailComponent } from './action/vehicle-detail/vehicle-detail.component';
import { InspectionComponent } from './action/inspection/inspection.component';
import { FieldInspectionComponent } from './action/inspection/field-inspection/field-inspection.component';
import { TechnicalInspectionComponent } from './action/inspection/technical-inspection/technical-inspection.component';
import { OwnerComponent } from './action/owner/owner.component';






@NgModule({
  declarations: [
    VehicleConfigComponent,
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
    OrcStockComponent,
    AisStockComponent,
    VehicleAdd,
    VehicleListComponent,

    VehicleLookupsComponent,
    VehicleOwnersComponent,    
    VehicleDocumentsComponent,
    AssignOwnersComponent, 
    VehicleDetailComponent,
    InspectionComponent,
    FieldInspectionComponent,
    TechnicalInspectionComponent,
    OwnerComponent

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
    //NgxMaskPipe
    NgxMaskDirective,
    NgxMaskPipe,

  ],
  providers: [
    DatePipe,
    LanguageService,
    provideNgxMask()
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class VehicleManagementModule { }
