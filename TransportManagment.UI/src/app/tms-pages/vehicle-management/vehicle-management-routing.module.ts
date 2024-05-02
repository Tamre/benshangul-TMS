import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehicleConfigComponent } from './vehicle-config/vehicle-config.component';
import { StockManagementComponent } from './stock-management/stock-management.component';


const routes: Routes = [

  {
    path: "vehicle-config",
    component: VehicleConfigComponent
  },
  {
    path: "stock-management",
    component: StockManagementComponent
  },
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VehicleManagementRoutingModule { }
