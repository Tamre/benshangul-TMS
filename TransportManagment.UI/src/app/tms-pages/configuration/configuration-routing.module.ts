import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";

// Components
import { CountryComponent } from "./country/country.component";
import { CompanyComponent } from "./company/company.component";

const routes: Routes = [
  {
    path: "location",
    component: CountryComponent,
  },
  {
    path: "company",
    component: CompanyComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule],
})
export class ConfigurationRoutingModule {}
