import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";

//components

import { TmsDashboardsComponent } from "./tms-dashboards/tms-dashboards.component";

const routes: Routes = [
  {
    path: "",
    component: TmsDashboardsComponent,
  },
  {
    path: "",
    loadChildren: () =>
      import("./configuration/configuration.module").then(
        (m) => m.ConfigurationModule
      ),
  },
  {
    path: "configuration",
    loadChildren: () =>
      import("./configuration/configuration.module").then(
        (m) => m.ConfigurationModule
      ),
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class TmsPagesRoutingModule {}
