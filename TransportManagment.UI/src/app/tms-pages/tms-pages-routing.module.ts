import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Component pages
import { DashboardComponent } from "./dashboards/dashboard/dashboard.component";


const routes: Routes = [
    {
        path: "",
        component: DashboardComponent
    },
  
    {
      path: 'config', loadChildren: () => import('./configuration/configuration.module').then(m => m.configurationModule)
    },
    {
      path: 'v-management', loadChildren: () => import('./vehicle-management/vehicle-management.module').then(m => m.VehicleManagementModule)
    },
    
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TmsPagesRoutingModule { }
