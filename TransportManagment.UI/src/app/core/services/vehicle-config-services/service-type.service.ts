import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { ServiceTypeGetDto, ServiceTypePostDto } from 'src/app/model/vehicle-configuration/service-type';

@Injectable({
  providedIn: 'root'
})
export class ServiceTypeService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllServiceType() {
    var headers = this.headers
    return this.http.get<ServiceTypeGetDto[]>(`${this.baseUrl}/vech-config/ServiceType/GetAll`,{headers});
  }
  updateServiceType(formData:ServiceTypePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/ServiceType/Update`,
      formData,{headers:headers}
    );
  }
  addServiceType(formData:ServiceTypePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/ServiceType/Add`,
      formData,{headers:headers}
    );
  }
}
