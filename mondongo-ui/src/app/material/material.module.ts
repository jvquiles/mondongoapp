import { NgModule } from '@angular/core';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';

const materialComponents = [
  MatCardModule,
  MatButtonModule
];

@NgModule({
  declarations: [],
  imports: [
    materialComponents
  ],
  exports: [
    materialComponents
  ]
})
export class MaterialModule { }