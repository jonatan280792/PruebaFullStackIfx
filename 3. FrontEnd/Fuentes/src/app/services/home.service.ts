import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceUtils } from '@utils/services-util';
import { ResponseLoginDto } from '@models/usuarioModelDto';
import { buildRoute, ServicesRoutes } from '@utils/services-routes';
import { EntidadModellDto } from '@models/entidadModelDto';
import { EmpleadoModelDto } from '@models/empleadoModelDto';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  constructor(
    private serviceUtils: ServiceUtils,
  ) { }

  public getEntidades(): Observable<EntidadModellDto[]> {
    return this.serviceUtils.buildRequest(ServicesRoutes.getEntidades, 'get');
  }

  public setEntidades(data: EntidadModellDto): Observable<any> {
    return this.serviceUtils.buildRequest(ServicesRoutes.setEntidades, 'post', data);
  }

  public putEntidades(data: EntidadModellDto): Observable<any> {
    return this.serviceUtils.buildRequest(buildRoute(ServicesRoutes.putEntidades, {
      idEntidad: data.idEntidad
    }), 'put', data);
  }

  public deleteEntidades(data: EntidadModellDto): Observable<any> {
    return this.serviceUtils.buildRequest(buildRoute(ServicesRoutes.deleteEntidades, {
      idEntidad: data.idEntidad
    }), 'delete');
  }



  public getEmpleados(idEntidad: string): Observable<EmpleadoModelDto[]> {
    return this.serviceUtils.buildRequest(buildRoute(ServicesRoutes.getEmpleados, {
      idEntidad: idEntidad
    }), 'get');
  }

  public setEmpleados(data: EmpleadoModelDto): Observable<any> {
    return this.serviceUtils.buildRequest(ServicesRoutes.setEmpleados, 'post', data);
  }

  public putEmpleados(data: EmpleadoModelDto): Observable<any> {
    return this.serviceUtils.buildRequest(buildRoute(ServicesRoutes.putEmpleados, {
      idEmpleado: data.idEmpleado
    }), 'put', data);
  }

  public deleteEmpleados(data: EmpleadoModelDto): Observable<any> {
    return this.serviceUtils.buildRequest(buildRoute(ServicesRoutes.deleteEmpleados, {
      idEmpleado: data.idEmpleado
    }), 'delete');
  }
}