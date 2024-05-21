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

import { SharedModule } from '../../shared/shared.module';


import { SortByCrmPipe } from "./sort-by.pipe";

import { DatePipe } from '@angular/common';
import { FeatherModule } from 'angular-feather';
import { allIcons } from 'angular-feather/icons';
import { DropzoneModule } from 'ngx-dropzone-wrapper';
import { SimplebarAngularModule } from 'simplebar-angular';

import { TranslateModule } from '@ngx-translate/core';
import { LanguageService } from 'src/app/core/services/language.service';
import { vehicleRoutingModule } from './vehicle-routing.module';
import { VehicleAdd } from './vehicle-add/vehicle-add.component';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { NgStepperModule } from 'angular-ng-stepper';
import { NgxSliderModule } from 'ngx-slider-v2';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { OwnerComponent } from './owner/owner.component';


@NgModule({
  declarations: [
    SortByCrmPipe,
    VehicleAdd,
    VehicleListComponent,
    OwnerComponent
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
    vehicleRoutingModule,
    SharedModule,
    NgbProgressbarModule,
    NgbNavModule,
    FeatherModule.pick(allIcons),
    SimplebarAngularModule,
    DropzoneModule,
    TranslateModule,
    NgxSliderModule,
    CdkStepperModule,
    NgStepperModule,
    
  ],
  providers: [
    DatePipe,
    LanguageService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class vehicleModule {
  constructor() {
    defineElement(lottie.loadAnimation);
  }
}
