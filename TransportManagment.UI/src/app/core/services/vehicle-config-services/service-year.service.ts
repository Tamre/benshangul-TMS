import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { ServiceYearGetDto, ServiceYearPostDto } from 'src/app/model/vehicle-configuration/service-year';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Injectable({
  providedIn: 'root'
})
export class ServiceYearService {

  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) { }

  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllServiceYear() {
    var headers = this.headers
    return this.http.get<ServiceYearGetDto[]>(`${this.baseUrl}/vech-config/ServiceType/GetAll`,{headers});
  }
  updateServiceYear(formData:ServiceYearPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/ServiceType/Update`,
      formData,{headers:headers}
    );
  }
  addServiceYear(formData:ServiceYearPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/ServiceType/Add`,
      formData,{headers:headers}
    );
  }
}
