import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenStorageService } from '../token-storage.service';
import { environment } from 'src/environments/environment';
import { FactoryPointGetDto, FactoryPointPostDto } from 'src/app/model/vehicle-configuration/factory-point';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Injectable({
  providedIn: 'root'
})
export class FactoryPointService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllFactoryPoint() {
    var headers = this.headers
    return this.http.get<FactoryPointGetDto[]>(`${this.baseUrl}/vech-config/FactoryPoint/GetAll`,{headers});
  }
  updateFactoryPoint(formData:FactoryPointPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/FactoryPoint/Update`,
      formData,{headers:headers}
    );
  }
  addFactoryPoint(formData:FactoryPointPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/FactoryPoint/Add`,
      formData,{headers:headers}
    );
  }
}
