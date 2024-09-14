import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
  ViewChild
} from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PropiedadesService } from '@services/util.service';
import { SetFieldsForm } from '@utils/mapping-fields.util';

@Component({
  selector: 'screen-formulary',
  template:
    `
    <div class="section-control">
      <mat-card>
        <div class="container">
          <div class="title">
            <h1 color="primary">{{ nombreTabla }} {{ dataElement ? 'Editar' : 'Crear' }}</h1>
          </div>
          <div class="formulary" *ngIf="formCampos">
            <form [formGroup]="formCampos">
              <div class="row">
                <div class="col-md-6" *ngFor="let field of camposForm">
                  <!-- Valida Inputs -->
                  <ng-container *ngIf="field.tipoCampo === 'varchar' || 
                    field.tipoCampo === 'int'">
                    <mat-form-field class="input-form" [floatLabel]="'always'" appearance="outline">
                      <mat-label>{{ field.nombreCampo }}</mat-label>
                      <input
                        matInput
                        placeholder="{{ field.nombreCampo }}"
                        class="custom-input"
                        maxlength="{{ field.longitud }}"
                        name="{{ field.nombreCampo }}"
                        formControlName="{{ field.nombreCampo }}"
                        type="{{ field.tipoCampo }}"/>
                      <mat-error *ngIf="field.obligatorio" class="mat-error">Campo requerido</mat-error>
                    </mat-form-field>
                  </ng-container>

                  <!-- Validators Slide-Toogle -->
                  <ng-container *ngIf="field.tipoCampo === 'bit'">
                    <label class="label-detail">{{ field.textoCampo }}</label>
                    <mat-form-field class="input-form" [floatLabel]="'always'">
                      <mat-slide-toggle
                        [color]="'warn'"
                        formControlName="{{ field.nombreCampo }}">
                      </mat-slide-toggle>
                      <textarea matInput hidden></textarea>
                      <mat-error *ngIf="field.obligatorio" class="mat-error">Campo requerido</mat-error>
                    </mat-form-field>
                  </ng-container>
                </div>
              </div>
            </form>

            <div class="button-actions">
              <button
                mat-raised-button
                class="section-btns"
                type="button"
                [disabled]="formCampos.status === 'INVALID'"
                (click)="processForm()"
                color="primary">
                {{ dataElement ? 'Actualizar' : 'Nuevo' }}
              </button>
              <button
                mat-raised-button
                class="section-btns"
                (click)="close()"
              >Volver
              </button>
            </div>
          </div>
        </div>
      </mat-card>
    </div>
    `,
})

export class FormularyComponent implements OnChanges  {
  @Output() saveForm: EventEmitter<any> = new EventEmitter<any>();
  @Output() returnForm: EventEmitter<any> = new EventEmitter<any>();
  @Input() nombreTabla: string;
  @Input() dataElement: any;
  public formCampos: FormGroup;
  public camposForm: any

  constructor(
    private fb: FormBuilder,
    private propiedadesService: PropiedadesService
  ) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['dataElement'] || changes['nombreTabla']) {
      this.loadForm();
    }
  }

  loadForm(): void {
    if (this.nombreTabla) {
      this.propiedadesService.getEntidades(this.nombreTabla).subscribe({
        next: (propiedades) => {
          this.camposForm = propiedades;
          this.formCampos = this.fb.group(SetFieldsForm(this.camposForm, this.dataElement));
        },
        error: () => {
        }
      });
    }
  }

  processForm() {
    this.saveForm.emit(this.formCampos.getRawValue());
  }

  close() {
    this.returnForm.emit();
  }
}