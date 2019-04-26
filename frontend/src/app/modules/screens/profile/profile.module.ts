import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';
import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileService } from './profile.service';
import { MaterialModule } from 'src/app/material.module';
import { MainInfoComponent } from './profile-details/main-info/main-info.component';
import { UserOrdersComponent } from './profile-details/user-orders/user-orders.component';
import { UserDeliversComponent } from './profile-details/user-delivers/user-delivers.component';

@NgModule({
  declarations: [ProfileEditComponent, ProfileDetailsComponent, MainInfoComponent, UserOrdersComponent, UserDeliversComponent],
  imports: [
    CommonModule,
    ProfileRoutingModule,
    MaterialModule
  ],
  providers: [ProfileService]
})
export class ProfileModule { }
