import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { ScreensRoutingModule } from './screens-routing.module';

@NgModule({
  imports: [
    CommonModule,
    ScreensRoutingModule
  ],
  declarations: [HomeComponent]
})
export class ScreensModule { }
