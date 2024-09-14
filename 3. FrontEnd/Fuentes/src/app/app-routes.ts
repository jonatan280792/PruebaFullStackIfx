import { Routes } from '@angular/router';
import { SessionAuthGuard } from './guards/session-auth.guard';

const AppRoutes: Routes = [
  {
    loadChildren: () => import('@modules/login/login.module').then((m) => m.LoginModule),
    path: '',
  },
  {
    // Solo puede si tiene sesion activa
    canActivate: [SessionAuthGuard],
    loadChildren: () => import('@modules/home/home.module').then((m) => m.HomeModule),
    path: 'home',
  },
  {
    path: '**',
    pathMatch: 'full',
    redirectTo: 'home'
  }
];

export { AppRoutes };