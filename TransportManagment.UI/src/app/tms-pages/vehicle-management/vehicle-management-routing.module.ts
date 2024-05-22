import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehicleConfigComponent } from './configuratuion/vehicle-config/vehicle-config.component';
import { StockManagementComponent } from './configuratuion/stock-management/stock-management.component';
import { VehicleListComponent } from './action/vehicle-list/vehicle-list.component';
import { VehicleAdd } from './action/vehicle-add/vehicle-add.component';
import { OwnerComponent } from './action/owner/owner.component';



const routes: Routes = [

  {
    path: "vehicle-config",
    component: VehicleConfigComponent
  },
  {
    path: "stock-management",
    component: StockManagementComponent
  },
  {
    path: "list",
    component: VehicleListComponent
  },
  {
    path: "add",
    component: VehicleAdd
  },
  {
    path: "owner",
    component: OwnerComponent
  },
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VehicleManagementRoutingModule { }
