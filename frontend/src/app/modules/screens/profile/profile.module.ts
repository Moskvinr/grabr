import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileEditComponent } from './profile-edit/profile-edit.component';
import { ProfileDetailsComponent } from './profile-details/profile-details.component';

@NgModule({
  declarations: [ProfileEditComponent, ProfileDetailsComponent],
  imports: [
    CommonModule
  ]
})
export class ProfileModule { }
