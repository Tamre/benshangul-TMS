import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

@Injectable({ providedIn: "root" })

export class CommonService {
  assetUrl: string = environment.assetUrl;


  getImageUrl(url:string){

    return `${this.assetUrl}/${url}`
  }

}