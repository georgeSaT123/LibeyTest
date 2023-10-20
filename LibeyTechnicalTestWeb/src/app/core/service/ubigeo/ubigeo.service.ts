import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UbigeoService {

  constructor(private http: HttpClient) { }

  public getAllUbigeos(regionCode: string, provinceCode : string): Observable<Ubigeo[]> {
    const uri = `${environment.pathLibeyTechnicalTest}api/Ubigeo/all?regionCode=${regionCode}&provinceCode=${provinceCode}`;
    return this.http.get<Ubigeo[]>(uri);
  }
}
