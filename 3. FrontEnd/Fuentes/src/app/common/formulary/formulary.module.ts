import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatCardModule } from '@angular/material/card';
import { FormularyComponent } from './formulary.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PropiedadesService } from '@services/util.service';

const declarations = [FormularyComponent];

const imports = [
  CommonModule,
  FormsModule,
  MatButtonModule,
  MatCardModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatSlideToggleModule,
  ReactiveFormsModule
];

@NgModule({
  declarations: declarations,
  exports: declarations,
  imports: imports,
  providers: [PropiedadesService]
})

export class FormularyModule {}
