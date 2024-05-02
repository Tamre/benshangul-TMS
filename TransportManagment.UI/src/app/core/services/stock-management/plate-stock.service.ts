import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { PaginatedResponse, PlateStockGetDto, PlateStockPostDto } from 'src/app/model/stock-management/plate-stock';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class PlateStockService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllPlateStock(pageNumber: number) {
    var headers = this.headers
    const params = new HttpParams().set('PageNumber', pageNumber.toString());
    return this.http.get<PaginatedResponse<PlateStockGetDto>>(`${this.baseUrl}/vech-action/PlateStock/GetAll`,{headers, params});
  }
  updatePlateStock(formData:PlateStockPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/BanBody/Update`,
      formData,{headers:headers}
    );
  }
  addPlateStock(formData:PlateStockPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-action/PlateStock/Add`,
      formData,{headers:headers}
    );
  }
}
