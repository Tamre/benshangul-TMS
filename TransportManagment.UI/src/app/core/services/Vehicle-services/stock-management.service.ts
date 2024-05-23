import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { AisStockGetDto, AisStockPostDto } from 'src/app/model/stock-management/ais-stock';
import {  PlateStockGetDto, PlateStockPostDto } from 'src/app/model/stock-management/plate-stock';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { OrcStockGetDto, OrcStockPostDto } from 'src/app/model/stock-management/orc-stock';
import { PaginatedResponse } from 'src/app/model/common';

@Injectable({
  providedIn: 'root'
})
export class StockManagementService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });

  getAllAisStock(pageNumber: number,pageSize: number, criteria: { columnName: string, filterValue: string }[],searchTerm: string) {
    var headers = this.headers
    var params = new HttpParams().set('PageNumber', pageNumber.toString())
    .set('PageSize', pageSize.toString())
    .set('SearchTerm', searchTerm);
    criteria.forEach((c, index) => {
      params = params
        .set(`Criteria[${index}].ColumnName`, c.columnName)
        .set(`Criteria[${index}].FilterValue`, c.filterValue);
    });
    return this.http.get<PaginatedResponse<AisStockGetDto>>(`${this.baseUrl}/vech-action/AISStock/GetAll`,{headers, params});
  }
  transferAisStock(data: { aisStockIds: string[], toZoneId: number }){
    var headers = this.headers
    const requestBody = {
      aisStockIds: data.aisStockIds,
      toZoneId: data.toZoneId
    };
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-action/AISStock/TransferToZone`,requestBody,
      {headers:headers}
    );
  }
  addAisStock(formData:AisStockPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-action/AISStock/Add`,
      formData,{headers:headers}
    );
  }
  
  getAllOrcStock(pageNumber: number,pageSize: number, criteria: { columnName: string, filterValue: string }[],searchTerm: string) {
    var headers = this.headers
    var params = new HttpParams().set('PageNumber', pageNumber.toString())
    .set('PageSize', pageSize.toString())
    .set('SearchTerm', searchTerm);
    criteria.forEach((c, index) => {
      params = params
        .set(`Criteria[${index}].ColumnName`, c.columnName)
        .set(`Criteria[${index}].FilterValue`, c.filterValue);
    });
    return this.http.get<PaginatedResponse<OrcStockGetDto>>(`${this.baseUrl}/vech-action/ORCStock/GetAll`,{headers, params});
  }
  transferOrcStock(data: { orcStockIds: string[], toZoneId: number }){
    var headers = this.headers
    const requestBody = {
      orcStockIds: data.orcStockIds,
      toZoneId: data.toZoneId
    };
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-action/ORCStock/TransferToZone`,requestBody,
      {headers:headers}
    );
  }
  addOrcStock(formData:OrcStockPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-action/ORCStock/Add`,
      formData,{headers:headers}
    );
  }

  getAllPlateStock(pageNumber: number, pageSize: number, criteria: { columnName: string, filterValue: string }[], searchTerm: string) {
    var headers = this.headers
    var params = new HttpParams().set('PageNumber', pageNumber.toString())
      .set('PageSize', pageSize.toString())
      .set('SearchTerm', searchTerm);
    criteria.forEach((c, index) => {
      params = params
        .set(`Criteria[${index}].ColumnName`, c.columnName)
        .set(`Criteria[${index}].FilterValue`, c.filterValue);
    });
    return this.http.get<PaginatedResponse<PlateStockGetDto>>(`${this.baseUrl}/vech-action/PlateStock/GetAll`, { headers, params });
  }
  transferPlateStock(data: { plateStockIds: string[], toZoneId: number }) {
    var headers = this.headers
    const requestBody = {
      plateStockIds: data.plateStockIds,
      toZoneId: data.toZoneId
    };
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-action/PlateStock/TransferToZone`, requestBody,
      { headers: headers }
    );
  }
  addPlateStock(formData: PlateStockPostDto) {
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-action/PlateStock/Add`,
      formData, { headers: headers }
    );
  }
  deletePlateStock(plateStockIds: string[]) {
    const headers = this.headers;
    const requestBody = {
      plateStockIds: plateStockIds
    };

    return this.http.delete(`${this.baseUrl}/vech-action/PlateStock/Delete`, {
      headers: headers,
      body: requestBody
    });
  }
}
