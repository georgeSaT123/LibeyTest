import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Region } from 'src/app/entities/region';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RegionService {

  constructor(private http: HttpClient) { }

  public getAllRegions(): Observable<Region[]> {
		const uri = `${environment.pathLibeyTechnicalTest}api/Region/all`;
		return this.http.get<Region[]>(uri);    
  }
}
