import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { SalvageValueGetDto, SalvageValuePostDto } from 'src/app/model/vehicle-configuration/salvage-value';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class SalvageValueService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllSalvageValue() {
    var headers = this.headers
    return this.http.get<SalvageValueGetDto[]>(`${this.baseUrl}/vech-config/SalvageValue/GetAll`,{headers});
  }
  updateSalvageValue(formData:SalvageValuePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/SalvageValue/Update`,
      formData,{headers:headers}
    );
  }
  addSalvageValue(formData:SalvageValuePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/SalvageValue/Add`,
      formData,{headers:headers}
    );
  }
}
