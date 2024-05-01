import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { ManufactureYearGetDto, ManufactureYearPostDto } from 'src/app/model/vehicle-configuration/manufacture-year';

@Injectable({
  providedIn: 'root'
})
export class ManufactureCountryService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllManufactureYear() {
    var headers = this.headers
    return this.http.get<ManufactureYearGetDto[]>(`${this.baseUrl}/vech-config/ManufacturingCountry`,{headers});
  }
  updateManufactureYear(formData:ManufactureYearPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/ManufacturingCountry`,
      formData,{headers:headers}
    );
  }
  addManufactureYear(formData:ManufactureYearPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/ManufacturingCountry`,
      formData,{headers:headers}
    );
  }
}
