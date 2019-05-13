import { Component, OnInit, Input, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/common/services/auth.service';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-main-info',
  templateUrl: './main-info.component.html',
  styleUrls: ['./main-info.component.scss']
})
export class MainInfoComponent implements OnInit {

  @Input() userInfo: any;
  profileId: string;

  constructor(public router: Router, private authService: AuthService, private route: ActivatedRoute) { }


  ngOnInit() {
    this.profileId = this.route.snapshot.params['id'];
  }

  logout() {
    this.authService.logout().subscribe(() => {
      this.router.navigateByUrl('account/login');
    });
  }

  toDialogs() {
    this.router.navigateByUrl(`/dialogs/${this.profileId}`);
  }

  get canLogout() {
    return this.userInfo.id === this.authService.getUserId;
  }
}