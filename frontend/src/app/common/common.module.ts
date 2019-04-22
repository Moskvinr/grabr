import { NgModule } from '@angular/core';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { CommonModule as CmnModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { AuthService } from './services/auth.service';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule } from '@angular/material';
import { MaterialModule } from '../material.module';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CmnModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    RouterModule
  ],
  declarations: [NotFoundComponent, NavBarComponent],
  providers: [AuthService],
  exports: [NotFoundComponent, NavBarComponent]
})
export class CommonModule { }
