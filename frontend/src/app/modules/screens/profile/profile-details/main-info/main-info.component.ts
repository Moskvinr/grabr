import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/common/services/auth.service';

@Component({
  selector: 'app-main-info',
  templateUrl: './main-info.component.html',
  styleUrls: ['./main-info.component.scss']
})
export class MainInfoComponent implements OnInit {

  @Input() userInfo: any;

  constructor(public router: Router, private authService: AuthService) { }

  ngOnInit() {
  }

  logout() {
    this.authService.logout().subscribe(() => {
      this.router.navigateByUrl('account/login');
    });
  }

  get canLogout() {
    return this.userInfo.id === this.authService.getUserId;
  }
}
