import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Component pages
import { AddressComponent } from './address/address.component';
import { DeviceListComponent } from './device-list/device-list.component';


const routes: Routes = [

  {
    path: "address",
    component: AddressComponent
  },

  
  {
    path: "devices",
    component: DeviceListComponent
  },

 
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class configurationRoutingModule {}
