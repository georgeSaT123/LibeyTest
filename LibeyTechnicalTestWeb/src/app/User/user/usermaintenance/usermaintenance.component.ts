import { Component, OnInit, ViewChild } from '@angular/core';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { NgForm } from '@angular/forms';
import Swal from 'sweetalert2';
import { Region } from 'src/app/entities/region';
import { DocTyp } from 'src/app/entities/doctyp';
import { RegionService } from 'src/app/core/service/region/region.service';
import { DocumenttypeService } from 'src/app/core/service/documenttype/documenttype.service';
import { ProvinceService } from 'src/app/core/service/province/province.service';
import { Province } from 'src/app/entities/province';
@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {
  @ViewChild('userForm') userForm!: NgForm;
  public user: any = {};
  public regions: Region[] = [];
  public doc : DocTyp[] = [];
  public provinces : Province[] = []

  constructor(
    private libeuserserv : LibeyUserService,
    private documentTypeServ : DocumenttypeService,
    private regionserv: RegionService,
    private provinceserv: ProvinceService
  ) { }
  ngOnInit(): void {
    this.getAllRegions();
    this.getAllDocumentTypes();
  }
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


  public getAllDocumentTypes(): void {
    this.documentTypeServ.getAllDocumentTypes().subscribe(documentType => {
      this.doc = documentType;
      console.log(documentType, "AllDocumentTypes");
    });
  }

  public getAllRegions(): void {
    this.regionserv.getAllRegions().subscribe(region => {
      this.regions = region;
      console.log(region, "AllRegions");
    });
  }

  public loadProvinces(regionCode: string) : void {
    this.provinceserv.getAllProvinces(regionCode).subscribe(province => {
      this.provinces = province;
      console.log(province, "AllProvincesByRegions");
    });
  }
}