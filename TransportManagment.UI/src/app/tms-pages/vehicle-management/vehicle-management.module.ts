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
import { VehicleTypeComponent } from './vehicle-config/vehicle-type/vehicle-type.component';
import { SortByCrmPipe } from '../configuration/sort-by.pipe';
import { StockTypeComponent } from './vehicle-config/stock-type/stock-type.component';
import { BanBodyComponent } from './vehicle-config/ban-body/ban-body.component';



@NgModule({
  declarations: [
    VehicleConfigComponent,
    VehicleTypeComponent,
    SortByCrmPipe,
    StockTypeComponent,
    BanBodyComponent
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
