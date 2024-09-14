import { Component, inject, OnInit, signal, viewChild } from '@angular/core';
import { CustomIconService } from '../../common/custom-icons/custom-icon.service';
import { MatAccordion } from '@angular/material/expansion';
import { HomeService } from '@services/home.service';
import { EntidadModellDto } from '@models/entidadModelDto';
import { ModalService } from '@common/modal/modal.service';
import { EmpleadoModelDto } from '@models/empleadoModelDto';
import { ValidarPropiedadEntidad } from '@utils/mapping-fields.util';
import { MatSnackBar } from '@angular/material/snack-bar';
import moment from 'moment'
import { SessionService } from '@utils/session-util';
import { UsuarioModelDto } from '@models/usuarioModelDto';

@Component({
  selector: 'screen-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  accordion = viewChild.required(MatAccordion);
  private _snackBar = inject(MatSnackBar);
  readonly panelOpenState = signal(false);
  public showModal: boolean
  public modeModal: string
  public nombreTabla: string;
  public dataElement: any
  public idModal = 'idModalFormulario';
  public userLogin: UsuarioModelDto

  public listEntidades: EntidadModellDto[] = []

  public listEmpleados: EmpleadoModelDto[] = []

  constructor(
    private customIconService: CustomIconService,
    private homeService: HomeService,
    private modalService: ModalService,
    public sessionService: SessionService
  ) {
    this.userLogin = this.sessionService.getSessionData();
    this.customIconService.init();
  }

  ngOnInit(): void {
    // Se valida si no es administrador
    if (this.userLogin.rol == 2) {
      this.openSnackBar("Usted no es administrador, no podra ni editar ni elimiar Información");
    }

    this.loadEntidades();
  }

  loadEntidades() {
    this.homeService.getEntidades().subscribe({
      next: (entidades) => {
        this.listEntidades = entidades
        console.log(this.listEntidades);
      },
      error: () => {
        this.sessionService.logoutUser();
      },
      complete: () => {

      }
    })
  }

  loadEmpleados(idEntidad: string) {
    this.homeService.getEmpleados(idEntidad).subscribe({
      next: (empleados) => {
        this.listEmpleados = empleados
        console.log(this.listEntidades);
      },
      error: () => {

      },
      complete: () => {

      }
    })
  }

  openEmpresa(entidad: EntidadModellDto) {
    
    this.loadEmpleados(entidad.idEntidad.toString());
  }

  processAction(nombreTabla: string, data?: any) {
    this.dataElement = data;
    this.nombreTabla = nombreTabla;
    this.showModal = false;
    
    setTimeout(() => {
      this.showModal = true;
      this.modalService.open(this.idModal);
    });
  }

  saveForm(event: any) {
    const data = event;
    data.fechaCreacion = moment()

    if (this.modeModal === 'edit') {
      if (ValidarPropiedadEntidad('entidad', data)) {
        this.homeService.putEntidades(data).subscribe({
          next: (response) => {
            this.loadEntidades();
            this.openSnackBar(response.message);
          },
          error: () => {
    
          },
          complete: () => {
            this.modalClose();
            
          }
        })
      } else {
        this.homeService.putEmpleados(data).subscribe({
          next: (response) => {
            this.loadEmpleados(response.transaction);
            this.openSnackBar(response.message);
            console.log(response);
          },
          error: () => {
    
          },
          complete: () => {
            this.modalClose();
          }
        })
      }
    } else {
      if (ValidarPropiedadEntidad('entidad', data)) {
        this.homeService.setEntidades(data).subscribe({
          next: (response) => {
            this.loadEntidades();
            this.openSnackBar(response.message);
          },
          error: () => {
    
          },
          complete: () => {
            this.modalClose();
          }
        })
      } else {
        this.homeService.setEmpleados(data).subscribe({
          next: (response) => {
            this.loadEmpleados(response.transaction);
            this.openSnackBar(response.message);
          },
          error: () => {
    
          },
          complete: () => {
            this.modalClose();
          }
        })
      }
    }
  }

  deleteEntidades(entidad: EntidadModellDto) {
    this.homeService.deleteEntidades(entidad).subscribe({
      next: (response) => {
        this.loadEntidades();
        this.openSnackBar(response.message);
      },
      error: () => {

      },
    })
  }

  deleteEmpleados(empleado: EmpleadoModelDto) {
    this.homeService.deleteEmpleados(empleado).subscribe({
      next: (response) => {
        this.loadEntidades();
        this.openSnackBar(response.message);
      },
      error: () => {

      },
    })
  }

  modalClose() {
    this.modalService.close(this.idModal);
  }

  openSnackBar(message: string) {
    this._snackBar.open(message, 'Cerrar', {
      duration: 5000,
      horizontalPosition: 'center',
      verticalPosition: 'top',
    });
  }
}