import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'screen-footer',
  template: `<div class="mat-typography navigator-footer">
      Elaborado por Jonatan Rojas
    </div>`,
})
export class FooterComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {
    
  }
}