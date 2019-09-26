import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { UserModel } from '../model/UserModel';

@Injectable()
export class UserService {

    constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    }

    getUser(username: string, pass: string) {
        return this.httpClient.post(this.baseUrl + 'api/UserData/Login', {
            username: username,
            pass: pass,
        });
    }
}
