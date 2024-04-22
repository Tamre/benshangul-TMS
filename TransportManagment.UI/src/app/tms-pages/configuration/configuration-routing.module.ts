import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Component pages
import { AddressComponent } from './address/address.component';


const routes: Routes = [

  {
    path: "address",
    component: AddressComponent
  },
 
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class configurationRoutingModule {}
