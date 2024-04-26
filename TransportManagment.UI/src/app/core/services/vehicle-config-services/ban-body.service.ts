import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { BanBodyGetDto, BanBodyPostDto } from 'src/app/model/vehicle-configuration/ban-body';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Injectable({
  providedIn: 'root'
})
export class BanBodyService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllBanBody() {
    var headers = this.headers
    return this.http.get<BanBodyGetDto[]>(`${this.baseUrl}/vech-config/BanBody/GetAll`,{headers});
  }
  updateBanBody(formData:BanBodyPostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/BanBody/Update`,
      formData,{headers:headers}
    );
  }
  addBanBody(formData:BanBodyPostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/BanBody/Add`,
      formData,{headers:headers}
    );
  }
}
