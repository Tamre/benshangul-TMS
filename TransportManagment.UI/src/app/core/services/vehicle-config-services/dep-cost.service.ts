import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { DepCostGetDto, DepCostPostDto } from 'src/app/model/vehicle-configuration/dep-cost';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Injectable({
  providedIn: 'root'
})
export class DepCostService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllDepCost() {
    var headers = this.headers
    return this.http.get<DepCostGetDto[]>(`${this.baseUrl}/vech-config/DepreciationCost/GetAll`,{headers});
  }
  updateDepCost(formData:DepCostPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/DepreciationCost/Update`,
      formData,{headers:headers}
    );
  }
  addDepCost(formData:DepCostPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/DepreciationCost/Add`,
      formData,{headers:headers}
    );
  }
}
