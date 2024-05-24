import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { ResponseMessage } from "src/app/model/ResponseMessage.Model";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";
import { DeviceGetDto, DeviceRequestDto, User } from "src/app/model/user";

@Injectable({ providedIn: "root" })
export class UserProfileService {
  baseUrl: string = environment.baseUrl;
  macUrl:string = environment.macUrl;
  constructor(private http: HttpClient) {}
  /***
   * Get All User
   */
  

  login(formData: User) {
    
 
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/Authentication/Login`,
      formData
    );
  }

  devicePermissionRequest(permissionRequest: DeviceRequestDto) {   
 
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/DeviceList/Add`,
      permissionRequest
    );
  }

  UpdateDevice(updateRequestDto: DeviceGetDto) {   
 
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/DeviceList/Update`,
      updateRequestDto
    );
  }

  getDevices() {   
 
    return this.http.get<DeviceGetDto[]>(
      `${this.baseUrl}/DeviceList/GetAll?PageSize=10&PageNumber=1`
    );
  }

  getMacAddress(): Observable<any> {
    return this.http.get(this.macUrl);
  }
 
  /***
   * Facked User Register
   */
  register(user: User) {
    return this.http.post(`/users/register`, user);
  }
}
