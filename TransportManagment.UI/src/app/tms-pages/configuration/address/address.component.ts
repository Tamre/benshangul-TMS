import { Component } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { TranslateService } from "@ngx-translate/core";

import { projectDocument, ProjectTeam } from "src/app/core/data";
import { AddressService } from "src/app/core/services/address.service";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { UserView } from "src/app/model/user";
@Component({
  selector: "app-address",
  templateUrl: "./address.component.html",
  styleUrls: ["./address.component.scss"],
})
export class AddressComponent {
  projectListWidgets!: any;
  teamOverviewList: any;
  submitted = false;
  currentUser!: UserView | null;

  breadCrumbItems = [
    { label: "Admin" },
    { label: "Address", active: true },
  ];
  constructor(
    private modalService: NgbModal,
    private tokenStorageService:TokenStorageService,  
    public translate: TranslateService
  ) {
    translate.setDefaultLang('en');
  }
  labelT:string = "MENUITEMS.DASHBOARD.TEXT"
  ngOnInit(): void {
    /**
     * Fetches the data
     */
    this.currentUser = this.tokenStorageService.getCurrentUser()
    console.log("current user",this.currentUser)
    this.projectListWidgets = projectDocument;
    this.teamOverviewList = ProjectTeam;
    
  }

  /**
   * Open modal
   * @param content modal content
   */
  openModal(content: any) {
    this.submitted = false;
    this.modalService.open(content, { size: "md", centered: true });
  }

  /**
   * Active Toggle navbar
   */
  activeMenu(id: any) {
    document.querySelector(".star_" + id)?.classList.toggle("active");
  }
}
