import { Component, inject, OnInit } from '@angular/core';
import { UsuarioModelDto } from '@models/usuarioModelDto';
import { ThemeService } from '@services/theme-service';
import { SessionService } from '@utils/session-util';

@Component({
  selector: 'screen-header',
  template: `<div class="mat-typography">
        <section class="navigator-header">
          <mat-toolbar color="primary">
            <button mat-icon-button class="btn-menu" aria-label="Example icon-button with menu icon">
              <mat-icon svgIcon="menu"></mat-icon>
            </button>
            <span>Bienvenido: {{ userLogin.nombreUsuario }} - {{ userLogin.rol === 1 ? 'Administrador' : 'Invitado' }} </span>
            <span class="order-items"></span>
            
            
            <a (click)="toggleTheme()">
              <mat-icon *ngIf="themeService.themeSignal() === 'dark'" svgIcon="sun"></mat-icon>
              <mat-icon *ngIf="themeService.themeSignal() !== 'dark'" svgIcon="moon"></mat-icon>
            </a>
            <a (click)="logout()">
              <mat-icon svgIcon="logout"></mat-icon>
            </a>
          </mat-toolbar>
        </section>
    </div>`,
})
export class HeaderComponent implements OnInit {
  themeService: ThemeService = inject(ThemeService);

  public userLogin: UsuarioModelDto
  public language: string;

  constructor(
    public sessionService: SessionService,
  ) {
    this.userLogin = this.sessionService.getSessionData();
  }

  ngOnInit(): void {
    console.log()
  }

  toggleTheme() {
    this.themeService.updateTheme();
  }

  logout() {
    this.sessionService.removeAllLocalStorage();
    this.sessionService.removeAllSesionStorage();
    window.location.href = 'http://localhost:4200/#';
  }
}