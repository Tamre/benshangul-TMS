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
import { VehicleTypeComponent } from './vehicle-config/vehicle-attribute/vehicle-type/vehicle-type.component';
import { SortByCrmPipe } from '../configuration/sort-by.pipe';
import { StockTypeComponent } from './vehicle-config/services/stock-type/stock-type.component';
import { BanBodyComponent } from './vehicle-config/vehicle-attribute/ban-body/ban-body.component';
import { DepreciatioCostComponent } from './vehicle-config/financial/depreciatio-cost/depreciatio-cost.component';
import { SortByCrmPipe1 } from './sort-by.pipe';
import { DocumentTypeComponent } from './vehicle-config/documentation/document-type/document-type.component';
import { VehicleAttributeComponent } from './vehicle-config/vehicle-attribute/vehicle-attribute.component';
import { FinancialComponent } from './vehicle-config/financial/financial.component';
import { DocumentationComponent } from './vehicle-config/documentation/documentation.component';
import { ManufacturingComponent } from './vehicle-config/manufacturing/manufacturing.component';
import { ServicesComponent } from './vehicle-config/services/services.component';
import { TestComponent } from './vehicle-config/test/test.component';



@NgModule({
  declarations: [
    VehicleConfigComponent,
    VehicleTypeComponent,
    SortByCrmPipe1,
    StockTypeComponent,
    BanBodyComponent,
    DepreciatioCostComponent,
    DocumentTypeComponent,
    VehicleAttributeComponent,
    FinancialComponent,
    DocumentationComponent,
    ManufacturingComponent,
    ServicesComponent,
    TestComponent
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
