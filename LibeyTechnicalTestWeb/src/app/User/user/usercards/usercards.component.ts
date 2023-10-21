import { Component, OnInit } from "@angular/core";
import { LibeyUserService } from "src/app/core/service/libeyuser/libeyuser.service";

@Component({
	selector: "app-usercards",
	templateUrl: "./usercards.component.html",
	styleUrls: ["./usercards.component.css"],
})
export class UsercardsComponent implements OnInit {
	users: any[] = [];
	constructor(private libeyUserService: LibeyUserService) {}
	ngOnInit(): void {
		this.libeyUserService.Find("U002").subscribe(response => {
			console.log(response, "User");
		});
		//this.getAll();		
	}

	public getAll(): void {
		this.libeyUserService.getAllLibeyUsers().subscribe(response => {
			this.users = response;
			console.log(response, "AllUsers");
		});
	}

	public loadUsers(): void {
		this.getAll();
	}
}