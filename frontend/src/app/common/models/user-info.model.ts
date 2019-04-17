export class UserInfo {
    public accessToken: string;
    public userModel: UserModel;
}

class UserModel {
    public userName: string;
    public firstName: string;
    public secondName: string;
    public userId: string;
    public userRoles: string[];
}

