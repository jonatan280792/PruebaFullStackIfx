import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceUtils } from '@utils/services-util';
import { buildRoute, ServicesRoutes } from '@utils/services-routes';
import { EntidadModellDto } from '@models/entidadModelDto';
import { PropiedadesModelDto } from '@models/propiedadesModelDto';

@Injectable({
  providedIn: 'root',
})
export class PropiedadesService {
  constructor(
    private serviceUtils: ServiceUtils,
  ) { }

  public getEntidades(nombreTabla: string): Observable<PropiedadesModelDto[]> {
    return this.serviceUtils.buildRequest(buildRoute(ServicesRoutes.getPropiedades, {
        nombreTabla: nombreTabla
      }), 'get');
  }
}