import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
import { LibeyUserCommand } from "src/app/entities/Request/libeyusercommand";
@Injectable({
	providedIn: "root",
})
export class LibeyUserService {
	constructor(private http: HttpClient) {}

	public Find(documentNumber: string): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.get<LibeyUser>(uri);
	}

	public getAllLibeyUsers(): Observable<LibeyUser[]> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/all`;
		return this.http.get<LibeyUser[]>(uri);
	}
	public createUser(command: LibeyUserCommand): Observable<any> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
		return this.http.post(uri, command);
	}	  
}