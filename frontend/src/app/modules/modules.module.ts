import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModulesRoutingModule } from './modules-routing.module';
import { FormsControlModule } from './forms-control/forms-control.module';

@NgModule({
  imports: [
    CommonModule,
    ModulesRoutingModule,
    FormsControlModule
  ],
  declarations: []
})
export class ModulesModule { }
