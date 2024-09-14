import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ServiceUtils } from '@utils/services-util';
import { ResponseLoginDto } from '@models/usuarioModelDto';
import { ServicesRoutes } from '@utils/services-routes';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(
    private serviceUtils: ServiceUtils,
  ) { }

  public doLogin(data: any): Observable<ResponseLoginDto> {
    return this.serviceUtils.buildRequest(ServicesRoutes.doLogin, 'post', data);
  }
}