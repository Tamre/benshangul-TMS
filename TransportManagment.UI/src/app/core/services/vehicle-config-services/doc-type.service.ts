import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { TokenStorageService } from '../token-storage.service';
import { DocTypeGetDto, DocTypePostDto } from 'src/app/model/vehicle-configuration/doc-type';
import { ResponseMessage } from 'src/app/model/ResponseMessage.Model';

@Injectable({
  providedIn: 'root'
})
export class DocTypeService {

  baseUrl: string = environment.baseUrl;
  

  constructor(private http: HttpClient, private tokenStorageService:TokenStorageService) {}
  /***
   * Get All User
   */
  headers = new HttpHeaders({
    'Authorization': `Bearer ${this.tokenStorageService.getToken()}`,
    'Content-Type': 'application/json'
  });
  getAllDocType() {
    var headers = this.headers
    return this.http.get<DocTypeGetDto[]>(`${this.baseUrl}/vech-config/DocumentType/GetAll`,{headers});
  }
  updateDocType(formData:DocTypePostDto){
    var headers = this.headers
    return this.http.put<ResponseMessage>(
      `${this.baseUrl}/vech-config/DocumentType/Update`,
      formData,{headers:headers}
    );
  }
  addDocType(formData:DocTypePostDto){
    var headers = this.headers
    return this.http.post<ResponseMessage>(
      `${this.baseUrl}/vech-config/DocumentType/Add`,
      formData,{headers:headers}
    );
  }
}
