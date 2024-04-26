import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { StockTypeGetDto, StockTypePostDto } from 'src/app/model/vehicle-configuration/stock-type';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Injectable({
  providedIn: 'root'
})
export class StockTypeService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllStockType() {
    var headers = this.headers
    return this.http.get<StockTypeGetDto[]>(`${this.baseUrl}/vech-config/AISORCStockType/GetAll`,{headers});
  }
  updateStockType(formData:StockTypePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/AISORCStockType/Update`,
      formData,{headers:headers}
    );
  }
  addStockType(formData:StockTypePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/AISORCStockType/Add`,
      formData,{headers:headers}
    );
  }
}
