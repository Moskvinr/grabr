import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { finalize } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-profile-details',
  templateUrl: './profile-details.component.html',
  styleUrls: ['./profile-details.component.scss']
})
export class ProfileDetailsComponent implements OnInit {

  profileDetails: Profile;
  isLoading = false;
  constructor(private profileService: ProfileService, private route: ActivatedRoute) { }

  ngOnInit() {
    const profileId = this.route.snapshot.params['id'];
    this.isLoading = true;
    let profileInfo;
    profileInfo = profileId ? this.profileService.getOtherUserInfo(profileId) : this.profileService.getUserInfo();
    profileInfo.pipe(finalize(() => this.isLoading = false))
      .subscribe(info => {
        this.profileDetails = info;
      });
  }

}
