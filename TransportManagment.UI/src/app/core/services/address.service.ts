import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { ResponseMessage } from "src/app/model/ResponseMessage.Model";
import { environment } from "src/environments/environment";

import { TokenStorageService } from "./token-storage.service";
import { Country } from "src/app/model/address/country";
import { Region } from "src/app/model/address/region";
import { Zone } from "src/app/model/address/zone";
import { Woreda } from "src/app/model/address/woreda";
import { User } from "src/app/model/user";
@Injectable({ providedIn: "root" })

export class AddressService {
  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllCountries() {
    var headers = this.headers
    return this.http.get<Country[]>(`${this.baseUrl}/Country/GetAll`,{headers});
  }
  addCountry(formData:Country){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/Country/Add`,
      formData,{headers:headers}
    );
  }
  updateCountry(formData:Country){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/Country/Update`,
      formData,{headers:headers}
    );
  }
  // Region
  getAllRegion() {
    var headers = this.headers
    return this.http.get<Region[]>(`${this.baseUrl}/Region/GetAll`,{headers});
  }
  addRegion(formData:Region){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/Region/Add`,
      formData,{headers:headers}
    );
  }
  updateRegion(formData:Region){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/Region/Update`,
      formData,{headers:headers}
    );
  }
  

  //zone 
  getAllZone() {
    var headers = this.headers
    return this.http.get<Zone[]>(`${this.baseUrl}/Zone/GetAll`,{headers});
  }
  addZone(formData:Zone){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/Zone/Add`,
      formData,{headers:headers}
    );
  }
  updateZone(formData:Zone){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/Zone/Update`,
      formData,{headers:headers}
    );
  }

  // woreda
  getAllWoreda() {
    var headers = this.headers
    return this.http.get<Woreda[]>(`${this.baseUrl}/Woreda/GetAll`,{headers});
  }
  addWoreda(formData:Woreda){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/Woreda/Add`,
      formData,{headers:headers}
    );
  }
  updateWoreda(formData:Woreda){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/Woreda/Update`,
      formData,{headers:headers}
    );
  }
  login(formData: User) {
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/Authentication/Login`,
      formData
    );
  }

  /***
   * Facked User Register
   */
  register(user: User) {
    return this.http.post(`/users/register`, user);
  }
}
