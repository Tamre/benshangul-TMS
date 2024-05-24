import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { ResponseMessage } from "src/app/model/ResponseMessage.Model";
import { environment } from "src/environments/environment";

import { TokenStorageService } from "../token-storage.service";
import { GetVehicleDetailRequestDto, VehicleData } from "src/app/model/vehicle";
import { IVehicleOwnerGetDto, VehicleOwnerPostDto } from "src/app/tms-pages/vehicle-management/action/vehicle-owners/IVehicleOwnersDto";
import { PaginatedResponse } from "src/app/model/common";
import { OwnerGetDto, OwnerPostDto } from "src/app/tms-pages/vehicle-management/action/owner/IownerDto";
import { CreateFieldInspectionDto } from "src/app/model/inspection/CreateFieldInspection";
import { CreateTechnicalInspectionDto } from "src/app/model/inspection/CreateTechnicalInspection";
@Injectable({ providedIn: "root" })

export class InspectionService {
  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`
  });

  createFieldInspection(formData:CreateFieldInspectionDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/Inspection/CreateFieldInspection`,
      formData,{headers:headers}
    );
  }
  CreateTechnicalInspection(formData:CreateTechnicalInspectionDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/Inspection/CreateTechnicalInspection`,
      formData,{headers:headers}
    );
  }
}