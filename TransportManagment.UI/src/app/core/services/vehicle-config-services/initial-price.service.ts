import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';
import { InitialPriceGetDto, InitialPricePostDto } from 'src/app/model/vehicle-configuration/initial-price';
import { TokenStorageService } from '../token-storage.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InitialPriceService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllInitialPrice() {
    var headers = this.headers
    return this.http.get<InitialPriceGetDto[]>(`${this.baseUrl}/vech-config/InitialPrice/GetAll`,{headers});
  }
  updateInitialPrice(formData:InitialPricePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/InitialPrice/Update`,
      formData,{headers:headers}
    );
  }
  addInitialPrice(formData:InitialPricePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/InitialPrice/Add`,
      formData,{headers:headers}
    );
  }
}
