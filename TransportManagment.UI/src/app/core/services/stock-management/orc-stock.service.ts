import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { OrcStockGetDto, OrcStockPostDto } from 'src/app/model/stock-management/orc-stock';
import { PaginatedResponse } from 'src/app/model/stock-management/plate-stock';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class OrcStockService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });

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
}
