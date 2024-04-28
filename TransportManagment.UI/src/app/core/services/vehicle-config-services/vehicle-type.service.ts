import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenStorageService } from '../token-storage.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class VehicleTypeService {
  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) { }

  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllVehicleTypes() {
    var headers = this.headers
    //return this.http.get<Country[]>(`${this.baseUrl}/Country/GetAll`,{headers});
  }
}
