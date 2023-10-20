import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DocTyp } from 'src/app/entities/doctyp';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DocumenttypeService {

  constructor(private http: HttpClient) {}

	public getAllDocumentTypes(): Observable<DocTyp[]> {
		const uri = `${environment.pathLibeyTechnicalTest}api/DocumentType/all`;
		return this.http.get<DocTyp[]>(uri);
  }
}
