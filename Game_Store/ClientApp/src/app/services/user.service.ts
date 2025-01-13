import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "../models/user.model";

@Injectable()
export class UserService {
    currentUser : User | null = null;

    constructor (private http:HttpClient) {}

    readonly baseUrl = 'https://localhost:7222/api/users';

    signIn(user: User) : Observable<User> {
        return this.http.post<User>(this.baseUrl + '/signIn', user);
    }

    isLoggedIn() : boolean {
        return this.currentUser !== null;
    }
}