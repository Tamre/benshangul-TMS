import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AddressComponent } from '../configuration/address/address.component';
import { VehicleConfigComponent } from './vehicle-config/vehicle-config.component';
import { StockTypeComponent } from './vehicle-config/services/stock-type/stock-type.component';
import { BanBodyComponent } from './vehicle-config/vehicle-attribute/ban-body/ban-body.component';
import { DepreciatioCostComponent } from './vehicle-config/financial/depreciatio-cost/depreciatio-cost.component';
import { VehicleAttributeComponent } from './vehicle-config/vehicle-attribute/vehicle-attribute.component';
import { FinancialComponent } from './vehicle-config/financial/financial.component';
import { DocumentationComponent } from './vehicle-config/documentation/documentation.component';
import { ManufacturingComponent } from './vehicle-config/manufacturing/manufacturing.component';
import { ServicesComponent } from './vehicle-config/services/services.component';

const routes: Routes = [

  {
    path: "vehicle-config",
    component: VehicleConfigComponent
  },
  {
    path: "vehicle-attribute",
    component: VehicleAttributeComponent
  },
  {
    path: "financial",
    component: FinancialComponent
  },
  {
    path: "documentation",
    component: DocumentationComponent
  },
  {
    path: "manufacturing",
    component: ManufacturingComponent
  },
  {
    path: "services",
    component: ServicesComponent
  },
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VehicleManagementRoutingModule { }
