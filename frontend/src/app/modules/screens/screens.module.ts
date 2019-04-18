import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { ScreensRoutingModule } from './screens-routing.module';
import { ProfileModule } from './profile/profile.module';

@NgModule({
  imports: [
    CommonModule,
    ScreensRoutingModule,
    ProfileModule
  ],
  declarations: [HomeComponent]
})
export class ScreensModule { }
