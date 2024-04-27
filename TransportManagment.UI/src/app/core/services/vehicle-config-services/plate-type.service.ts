import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { PlateTypeGetDto, PlateTypePostDto } from 'src/app/model/vehicle-configuration/plate-type';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Injectable({
  providedIn: 'root'
})
export class PlateTypeService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllPlateType() {
    var headers = this.headers
    return this.http.get<PlateTypeGetDto[]>(`${this.baseUrl}/vech-config/PlateType/GetAll`,{headers});
  }
  updatePlateType(formData:PlateTypePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/PlateType/Update`,
      formData,{headers:headers}
    );
  }
  addPlateType(formData:PlateTypePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/PlateType/Add`,
      formData,{headers:headers}
    );
  }
}
