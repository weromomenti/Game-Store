import { Game } from "../models/game.model";
import{ HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { map, Observable } from "rxjs";

@Injectable()
export class GamesService {

    constructor (private http:HttpClient) {}

    readonly baseUrl = 'https://localhost:7222/api/games';

    getAllGames() : Observable<Game[]> {
        return this.http.get<Game[]>(this.baseUrl);
    }
    getGameByIdWithDetails(gameId : number) : Observable<Game> {
        return this.http.get<Game>(`${this.baseUrl}/${gameId}`);
    }
}
