import {
  NgModule
} from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRouting } from './home.routes';
import { RouterModule } from '@angular/router';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatCardModule} from '@angular/material/card';
import { LoginService } from '@services/login-service';
import { ServiceUtils } from '@utils/services-util';
import { SessionService } from '@utils/session-util';
import { SharedModule } from '@shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatExpansionModule } from '@angular/material/expansion';
import { HomeService } from '@services/home.service';
import { ModalModule } from '@common/modal/modal.module';
import { ModalService } from '@common/modal/modal.service';
import { FormularyModule } from '@common/formulary/formulary.module';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatChipsModule } from '@angular/material/chips';
import { MainHttpInterceptor } from '@interceptors/main-http-interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

const components = [HomeComponent];

const imports = [
  CommonModule,
  HomeRouting,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  ReactiveFormsModule,
  RouterModule,
  MatToolbarModule, MatButtonModule, MatIconModule, MatSlideToggleModule, MatCardModule,
  MatTableModule,
  MatExpansionModule,
  ModalModule,
  MatSnackBarModule,
  MatChipsModule,
  FormularyModule,
  SharedModule
];

const providers = [
  HomeService,
  ModalService,
  SessionService,
  ServiceUtils,
  {
    multi: true,
    provide: HTTP_INTERCEPTORS,
    useClass: MainHttpInterceptor
  },
];

@NgModule({
  declarations: components,
  exports: components,
  imports: imports,
  providers: providers,
})
export class HomeModule {}