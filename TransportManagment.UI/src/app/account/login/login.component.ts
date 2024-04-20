import { Component, OnInit } from "@angular/core";
import {
  UntypedFormBuilder,
  UntypedFormGroup,
  Validators,
} from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

// Login Auth
import { environment } from "../../../environments/environment";
import { AuthenticationService } from "../../core/services/auth.service";

import { first } from "rxjs/operators";
import { ToastService } from "./toast-service";
import { Store } from "@ngrx/store";
import { login } from "src/app/store/Authentication/authentication.actions";
import { UserProfileService } from "src/app/core/services/user.service";
import { TokenStorageService } from "src/app/core/services/token-storage.service";
import { caesarCipherEncrypt } from "src/app/core/helpers/cipher";

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

  // set the current year
  year: number = new Date().getFullYear();

  constructor(
    private formBuilder: UntypedFormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router,
    private userService: UserProfileService,
    private route: ActivatedRoute,
    public toastService: ToastService,
    private tokenStorageService:TokenStorageService,
    private store: Store
  ) {
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(["/"]);
    }
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
    if (this.loginForm.valid) {
      this.userService
        .login({
          username: this.loginForm.value.email,
          password: caesarCipherEncrypt(this.loginForm.value.password,3),
        })
        .subscribe({
          next: (res) => {
            if (res.success) {
              this.toastService.show(res.message, {
                classname: "bg-success text-white",
                delay: 15000,
              });
              this.tokenStorageService.saveToken(res.data)
              console.log("my token",this.tokenStorageService.getToken())
              sessionStorage.setItem("currentUser", res.data);
              sessionStorage.setItem("token",res.data)
              this.router.navigate(["/"]);
            } else {
              this.toastService.show(res.message, {
                classname: "bg-danger text-white",
                delay: 15000,
              });
            }
          },
          error: (err) => {
            console.log(err);
          },
        });
    }

    //  // Login Api
    //  this.store.dispatch(login({ email: this.f['email'].value, password: this.f['password'].value }));
    // // this.authenticationService.login(this.f['email'].value, this.f['password'].value).subscribe((data:any) => {
    // //   if(data.status == 'success'){
    // //     sessionStorage.setItem('toast', 'true');
    // //     sessionStorage.setItem('currentUser', JSON.stringify(data.data));
    // //     sessionStorage.setItem('token', data.token);
    // //     this.router.navigate(['/']);
    // //   } else {
    // //     this.toastService.show(data.data, { classname: 'bg-danger text-white', delay: 15000 });
    // //   }
    // // });

    // // stop here if form is invalid
    // // if (this.loginForm.invalid) {
    // //   return;
    // // } else {
    // //   if (environment.defaultauth === 'firebase') {
    // //     this.authenticationService.login(this.f['email'].value, this.f['password'].value).then((res: any) => {
    // //       this.router.navigate(['/']);
    // //     })
    // //       .catch(error => {
    // //         this.error = error ? error : '';
    // //       });
    // //   } else {
    // //     this.authFackservice.login(this.f['email'].value, this.f['password'].value).pipe(first()).subscribe(data => {
    // //           this.router.navigate(['/']);
    // //         },
    // //         error => {
    // //           this.error = error ? error : '';
    // //         });
    // //   }
    // // }
  }

  /**
   * Password Hide/Show
   */
  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
  }
}
