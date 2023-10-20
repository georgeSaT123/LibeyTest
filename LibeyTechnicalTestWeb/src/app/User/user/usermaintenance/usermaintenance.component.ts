import { Component, OnInit, ViewChild } from '@angular/core';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { NgForm } from '@angular/forms';
import { LibeyUserCommand } from 'src/app/entities/Request/libeyusercommand';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {
  @ViewChild('userForm') userForm!: NgForm;
  public user: any = {};
  constructor(
    private libeuserserv : LibeyUserService
  ) { }
  ngOnInit(): void {}
  public Submit(userForm: NgForm): void {
    const formValues = userForm.value;
    const user = {
      documentNumber: formValues.documentNumber,
      documentTypeId: formValues.documentTypeId,
      name: formValues.name,
      fathersLastName: formValues.fathersLastName,
      mothersLastName: formValues.mothersLastName,
      address: formValues.address,
      ubigeoCode: formValues.ubigeoCode,
      phone: formValues.phone,
      email: formValues.email,
      password: formValues.password
    };

    this.libeuserserv.createUser(user).subscribe(
      (response) => {
        Swal.fire('Usuario creado correctamente', response, 'success');
      },
      (error) => {
        Swal.fire('Error al crear usuario', error , 'error');
      }
    );
  }

  validateTypeDoc() {
    return !this.user.documentTypeId;
  }

  public clearForm(): void {
    this.userForm.reset(); 
  }
  
}