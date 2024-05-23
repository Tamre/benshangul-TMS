import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
//import { PaginatedResponse } from 'src/app/model/stock-management/plate-stock';
import { OwnerGetDto, OwnerPostDto } from 'src/app/model/vehicle/owner';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { PaginatedResponse } from 'src/app/model/common';

@Injectable({
  providedIn: 'root'
})
export class OwnerService {

  baseUrl: string = environment.baseUrl;


  constructor(private http: HttpClient, private tokenStorageService: TokenStorageService) { }
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });

  getAllOwner(pageNumber: number, pageSize: number, criteria: { columnName: string, filterValue: string }[]) {
    var headers = this.headers
    var params = new HttpParams().set('PageNumber', pageNumber.toString())
      .set('PageSize', pageSize.toString())
    criteria.forEach((c, index) => {
      params = params
        .set(`Criteria[${index}].ColumnName`, c.columnName)
        .set(`Criteria[${index}].FilterValue`, c.filterValue);
    });
    return this.http.get<PaginatedResponse<OwnerGetDto>>(`${this.baseUrl}/OwnerList/GetAllOwners`, { headers, params });
  }
  addOwner(formData:OwnerPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/OwnerList/AddOwner`,
      formData,{headers:headers}
    );
  }
  updateOwner(formData:OwnerPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/OwnerList/UpdateOwner`,
      formData,{headers:headers}
    );
  }
}
