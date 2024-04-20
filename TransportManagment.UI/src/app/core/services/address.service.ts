import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from "src/app/store/Authentication/auth.models";
import { ResponseMessage } from "src/app/model/ResponseMessage.Model";
import { environment } from "src/environments/environment";
import { Country } from "src/app/model/country";
import { TokenStorageService } from "./token-storage.service";
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
