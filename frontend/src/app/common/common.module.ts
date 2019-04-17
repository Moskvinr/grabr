import { NgModule } from '@angular/core';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { CommonModule as CmnModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { AuthService } from './services/auth.service';

@NgModule({
  imports: [
    CmnModule
  ],
  declarations: [NotFoundComponent, NavBarComponent],
  providers: [AuthService],
  exports: [NotFoundComponent, NavBarComponent]
})
export class CommonModule { }
