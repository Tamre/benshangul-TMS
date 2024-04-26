import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehicleConfigComponent } from './vehicle-config/vehicle-config.component';


const routes: Routes = [

  {
    path: "vehicle-config",
    component: VehicleConfigComponent
  },
 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VehicleManagementRoutingModule { }
