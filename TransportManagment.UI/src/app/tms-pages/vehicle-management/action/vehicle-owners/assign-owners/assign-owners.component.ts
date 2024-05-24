import { Component, Input, OnInit } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { UserView } from "src/app/model/user";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import {
  OwnerState,
  OwnerGroup,
  VehicleOwnerPostDto,
  IOwnerListDropdownDto,
} from "../IVehicleOwnersDto";

import { IActionDropDownDto, ISettingDropDownsDto } from "src/app/model/common";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";
import { ToastService } from "src/app/account/login/toast-service";
import { VehicleDropdownService } from "src/app/core/services/Vehicle-services/vehicle-drop-down.service";
import { VehicleService } from "src/app/core/services/Vehicle-services/vehicle.service";

@Component({
  selector: "app-assign-owners",

  templateUrl: "./assign-owners.component.html",
  styleUrl: "./assign-owners.component.scss",
})
export class AssignOwnersComponent implements OnInit {
  @Input() vehicleId!: string;
  userView!: UserView;
  vehicleOwnerForm!: FormGroup;

  ownerGroups : any =[
    {name:'Private_Owner',value:0},
    {name:'Organization',value:1},
    {name:'Government',value:2},
    {name:'Training Center',value:3},
  ]

  ownerStates : any =[
    {name:'CURRENT_OWNER',value:0},
    {name:'FORMER_OWNER',value:1},
    {name:'DELETED_OWNER',value:2},
    
  ]




  ownersLists: IOwnerListDropdownDto[] = [];
  ngOnInit(): void {
    this.userView = this.userService.getCurrentUser()!;
    this.vehicleOwnerForm = this.fb.group({
      vehicleId: [this.vehicleId, Validators.required],
      ownerId: [null],
      trainingCenterId: [null],
      ownerState: [OwnerState.CURRENT_OWNER, Validators.required],
      ownerGroup: [OwnerGroup.Private_Owner, Validators.required],
      createdById: [this.userView.userId, Validators.required],
    });
    this.getOwnerLists()

  }
  constructor(
    private fb: FormBuilder,
    private userService: TokenStorageService,
    private vehicleService : VehicleService,
    private activeModal:NgbActiveModal,
    private toastService : ToastService,
    private vehicleDropdownService : VehicleDropdownService
  ) {}

  onSubmit() {
    if (this.vehicleOwnerForm.valid) {
      const vehicleOwnerData: VehicleOwnerPostDto = this.vehicleOwnerForm.value;

      this.vehicleService.assignVehicleOwner(vehicleOwnerData).subscribe({
        next:(res)=>{

          if(res.success){

              this.toastService.show(res.message, {
                classname: "success text-white",
                delay: 2000,
              });
              this.closeModal();
          }
          else {
            this.toastService.show(res.message, {
              classname: "error text-white",
              delay: 2000,
            });
          }

        },error:(err)=>{

          this.toastService.show(err.message, {
            classname: "error text-white",
            delay: 2000,
          });

        }
      })


      console.log("Form Data:", vehicleOwnerData);
    }
  }

  getOwnerLists(){
    var ownerGroup = this.vehicleOwnerForm.value.ownerGroup;
    this.vehicleDropdownService.getOwnerListDropdown(Number(ownerGroup)).subscribe({
      next:(res:any)=>{
        this.ownersLists = res;

        console.log(this.ownersLists)
      }
    })
  }

  closeModal(){
    this.activeModal.close();
  }



  
}
