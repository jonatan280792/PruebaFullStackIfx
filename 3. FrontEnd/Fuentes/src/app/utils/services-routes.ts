import { Config } from '@config/index';

const { baseUrlMotor } = Config.api;

const ServicesRoutes = {
  getPropiedades: {
    needsAuth: false,
    url: baseUrlMotor + '/api/gestor/getPropiedades?nombreTabla=:nombreTabla',
  },
  doLogin: {
    needsAuth: false,
    url: baseUrlMotor + '/api/usuarios/doLogin',
  },
  getEntidades: {
    needsAuth: true,
    url: baseUrlMotor + '/api/gestor/getEntidades',
  },
  setEntidades: {
    needsAuth: true,
    url: baseUrlMotor + '/api/gestor/setEntidades',
  },
  putEntidades: {
    needsAuth: true,
    url: baseUrlMotor + '/api/gestor/putEntidades/:idEntidad',
  },
  deleteEntidades: {
    needsAuth: true,
    url: baseUrlMotor + '/api/gestor/deleteEntidades/:idEntidad',
  },
  getEmpleados: {
    needsAuth: true,
    url: baseUrlMotor + '/api/gestor/getEmpleados/:idEntidad',
  },
  setEmpleados: {
    needsAuth: true,
    url: baseUrlMotor + '/api/gestor/setEmpleados',
  },
  putEmpleados: {
    needsAuth: true,
    url: baseUrlMotor + '/api/gestor/putEmpleado/:idEmpleado',
  },
  deleteEmpleados: {
    needsAuth: true,
    url: baseUrlMotor + '/api/gestor/deleteEmpleado/:idEmpleado',
  }
};

const buildRoute = (path: any, params: any) => {
  const route = Object.assign({}, path);

  for (const key in params) {
    if (params.hasOwnProperty(key)) {
      route.url = route.url.replace(new RegExp(':' + key, 'g'), encodeURIComponent(params[key]) );
    }
  }

  return route;
};

export { buildRoute, ServicesRoutes };
