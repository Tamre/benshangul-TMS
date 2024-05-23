import { Component, Input, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";

import {
  IVehicleOwnerGetDto,
  OwnerGroup,
  OwnerState,
  VehicleOwnerPostDto,
} from "./IVehicleOwnersDto";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { User } from "src/app/store/Authentication/auth.models";
import { UserView } from "src/app/model/user";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { AssignOwnersComponent } from "./assign-owners/assign-owners.component";
import { VehicleService } from "src/app/core/services/Vehicle-services/vehicle.service";

@Component({
  selector: "app-vehicle-owners",
  templateUrl: "./vehicle-owners.component.html",
  styleUrl: "./vehicle-owners.component.scss",
})
export class VehicleOwnersComponent implements OnInit {
  @Input() vehicleId!: string;
  vehicleOwners: IVehicleOwnerGetDto[] = [];
 

  constructor(
    private vehicleService: VehicleService,    
    private modalService:NgbModal

  ) {}
  ngOnInit(): void {
  
    this.getVehicleOwnerByVehicleId();
  }

  getVehicleOwnerByVehicleId() {
    this.vehicleService.getVehicleOwnerByVehicleId(this.vehicleId).subscribe({
      next: (res) => {
        this.vehicleOwners = res;
        console.log("res",res);
      },
    });
  }




  assignOwners (){
    let modalRef= this.modalService.open(AssignOwnersComponent, {size:'lg',backdrop:"static"});
    modalRef.componentInstance.vehicleId = this.vehicleId
    modalRef.result.then((modal)=> {
      this.getVehicleOwnerByVehicleId()
    })
  }
}
