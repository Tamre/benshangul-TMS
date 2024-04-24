import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AddressComponent } from '../configuration/address/address.component';
import { VehicleConfigComponent } from './vehicle-config/vehicle-config.component';
import { StockTypeComponent } from './vehicle-config/stock-type/stock-type.component';
import { BanBodyComponent } from './vehicle-config/ban-body/ban-body.component';
import { DepreciatioCostComponent } from './vehicle-config/depreciatio-cost/depreciatio-cost.component';

const routes: Routes = [

  {
    path: "vehicle-config",
    component: VehicleConfigComponent
  },
  {
    path: "stock-type",
    component: StockTypeComponent
  },
  {
    path: "ban-body",
    component: BanBodyComponent
  },
  {
    path: "d-cost",
    component: DepreciatioCostComponent
  }
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VehicleManagementRoutingModule { }
