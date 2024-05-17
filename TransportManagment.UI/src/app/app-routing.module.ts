import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { LayoutComponent } from "./layouts/layout.component";
import { AuthGuard } from "./core/guards/auth.guard";

// Auth

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    loadChildren: () =>
      import("./tms-pages/tms-pages.module").then((m) => m.TmsPagesModule),
    canActivate: [AuthGuard],
  },

  {
    path: "auth",
    loadChildren: () =>
      import("./account/account.module").then((m) => m.AccountModule),
  },
  {
    path: "pages",
    loadChildren: () =>
      import("./extraspages/extraspages.module").then(
        (m) => m.ExtraspagesModule
      ),
    canActivate: [AuthGuard],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
