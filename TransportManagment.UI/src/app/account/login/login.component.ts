import { Component, OnInit } from "@angular/core";
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

// Login Auth
import { environment } from "../../../environments/environment";


import { first } from "rxjs/operators";
import { ToastService } from "./toast-service";


import { UserProfileService } from "src/app/core/services/user.service";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { caesarCipherEncrypt } from "src/app/core/helpers/cipher";
import { MacAddressServiceDto } from "src/app/model/common";
import { DeviceRequestDto } from "src/app/model/user";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})

/**
 * Login Component
 */
export class LoginComponent implements OnInit {
  // Login Form
  loginForm!: UntypedFormGroup;
  submitted = false;
  fieldTextType!: boolean;
  error = "";
  returnUrl!: string;
  toast!: false;

  macAddressDetails!: MacAddressServiceDto;

  errorMessage: string = "";
  userId: string = "";

  requestVissible: boolean = false;

  // set the current year
  year: number = new Date().getFullYear();

  constructor(
    private formBuilder: UntypedFormBuilder,
   
    private router: Router,
    private userService: UserProfileService,
    private route: ActivatedRoute,
    public toastService: ToastService,
    private tokenStorageService: TokenStorageService,

  ) {
    // redirect to home if already logged in

  }

  ngOnInit(): void {
    if (sessionStorage.getItem("currentUser")) {
      this.router.navigate(["/"]);
    }
    /**
     * Form Validatyion
     */
    this.loginForm = this.formBuilder.group({
      email: ["", [Validators.required]],
      password: ["", [Validators.required]],
    });
    // get return url from route parameters or default to '/'
    // this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.loginForm.controls;
  }

  /**
   * Form submit
   */
  onSubmit() {
    this.errorMessage = "";
    if (this.loginForm.valid) {
      this.userService.getMacAddress().subscribe({
        next: (res) => {
          this.macAddressDetails = res;
          if (this.macAddressDetails) {
            this.afterGettingMac();
          } else {
            this.toastService.show("MAC Service Is Not Runing ...", {
              classname: "error text-white",
              delay: 2000,
            });
          }
        },
        error: (res) => {
          this.toastService.show("MAC Service Is Not Runing ...", {
            classname: "error text-white",
            delay: 2000,
          });
        },
      });
    } else {
      this.errorMessage = "Please Check your Form!!!";

      this.toastService.show("Please Check your Form !!!", {
        classname: "error text-white",
        delay: 2000,
      });
    }
  }

  afterGettingMac() {
    this.userService
      .login({
        username: this.loginForm.value.email,
        password: caesarCipherEncrypt(this.loginForm.value.password, 3),
        macAddress: this.macAddressDetails.MacAddress,
      })
      .subscribe({
        next: (res) => {
          if (res.success) {
            this.toastService.show(res.message, {
              classname: "success text-white",
              delay: 2000,
            });
            this.tokenStorageService.saveToken(res.data);
            console.log("my token", this.tokenStorageService.getToken());
            sessionStorage.setItem("currentUser", res.data);
            sessionStorage.setItem("token", res.data);
            this.router.navigate(["/"]);
          } else {
            this.errorMessage = res.message;
            if (
              this.errorMessage === "Device Not Registerd Please Request !!!"
            ) {
              this.requestVissible = true;
              this.userId = res.data;
            }
            this.toastService.show(res.message, {
              classname: "error text-white",
              delay: 2000,
            });
          }
        },
        error: (err) => {
          this.errorMessage = err.message;
          console.log(err);
        },
      });
  }

  requestDevicePermission(){

    var DeviceRequest:DeviceRequestDto={
      PCNAme :this.macAddressDetails.PCName,
      MACAddress :this.macAddressDetails.MacAddress,
      IpAddress :this.macAddressDetails.IPAddress,
      CreatedById :this.userId
    }

    this.userService.devicePermissionRequest(DeviceRequest).subscribe({
      next:(res)=>{
        if(res.success){

          this.requestVissible=false;
          this.userId = ""

          this.toastService.show(res.message, {
            classname: "success text-white",
            delay: 2000,
          });




        }else{

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
    });
  }

  /**
   * Password Hide/Show
   */
  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
  }
}
