import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VehicleAdd } from './vehicle-add/vehicle-add.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';

// Component pages



const routes: Routes = [

  {
    path: "list",
    component: VehicleListComponent
  },
  {
    path: "add",
    component: VehicleAdd
  },
  
 
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class vehicleRoutingModule {}
