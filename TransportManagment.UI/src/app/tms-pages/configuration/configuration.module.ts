import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbPaginationModule, NgbTypeaheadModule, NgbTooltipModule, NgbDropdownModule, NgbAccordionModule, NgbNavModule, NgbProgressbarModule } from '@ng-bootstrap/ng-bootstrap';

// Flat Picker
import { FlatpickrModule } from 'angularx-flatpickr';

// Ng Select
import { NgSelectModule } from '@ng-select/ng-select';

// Load Icons
import { defineElement } from "@lordicon/element";
import lottie from 'lottie-web';

// Component pages
import { configurationRoutingModule } from './configuration-routing.module';
import { SharedModule } from '../../shared/shared.module';



import { DatePipe } from '@angular/common';
import { FeatherModule } from 'angular-feather';
import { allIcons } from 'angular-feather/icons';
import { DropzoneModule } from 'ngx-dropzone-wrapper';
import { SimplebarAngularModule } from 'simplebar-angular';
import { AddressComponent } from './address/address.component';
import { CountryComponent } from './country/country.component';
import { TranslateModule } from '@ngx-translate/core';
import { LanguageService } from 'src/app/core/services/language.service';
import { RegionComponent } from './region/region.component';
import { ZoneComponent } from './zone/zone.component';
import { WoredaComponent } from './woreda/woreda.component';
import { DeviceListComponent } from './device-list/device-list.component';
import { VehicleManagementModule } from '../vehicle-management/vehicle-management.module';

@NgModule({
  declarations: [
    CountryComponent,
    AddressComponent,
    RegionComponent,
    ZoneComponent,
    WoredaComponent,
    DeviceListComponent,
    
  ],
  imports: [
    CommonModule,
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
    NgbNavModule,
    FeatherModule.pick(allIcons),
    SimplebarAngularModule,
    DropzoneModule,
    TranslateModule,
    
  ],
  providers: [
    DatePipe,
    LanguageService,
    
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class configurationModule {
  constructor() {
    defineElement(lottie.loadAnimation);
  }
}
