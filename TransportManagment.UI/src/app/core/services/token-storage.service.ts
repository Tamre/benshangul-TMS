import { Injectable } from '@angular/core';
import { UserView } from 'src/app/model/user';

const TOKEN_KEY = 'auth-token';
const USER_KEY = 'currentUser';

@Injectable({
  providedIn: 'root'
})



export class TokenStorageService {
  constructor() { }

  signOut(): void {
    window.sessionStorage.clear();
  }

  public saveToken(token: string): void {
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(TOKEN_KEY, token);
  }

  public getToken(): string | null {
    return sessionStorage.getItem(TOKEN_KEY);
  }

  getCurrentUser(): UserView | null {
    const token = this.getToken();
    var payLoad = JSON.parse(window.atob(token!.split('.')[1]));

    console.log("payload",payLoad)
    let user: UserView = {
      userId: payLoad.userId,
      email: payLoad.email,
      id:payLoad.Id,
      userName: payLoad.sub
    }

    return user;
  }
  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);    
    if (user) {
      return JSON.parse(window.atob( user!.split('.')[1]));

    
    }

    return {};
  }
}
