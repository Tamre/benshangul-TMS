import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { User } from "src/app/store/Authentication/auth.models";
import { ResponseMessage } from "src/app/model/ResponseMessage.Model";
import { environment } from "src/environments/environment";

@Injectable({ providedIn: "root" })
export class UserProfileService {
  baseUrl: string = environment.baseUrl;
  constructor(private http: HttpClient) {}
  /***
   * Get All User
   */
  getAll() {
    return this.http.get<User[]>(`api/users`);
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
