import { Component, OnInit } from '@angular/core';
import { Game } from '../../models/game.model';
import { GamesService } from 'src/app/services/games.service';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.scss']
})
export class GamesComponent implements OnInit {

  allGames: Game[];

  constructor(private gameService : GamesService) { }

  getAllGames() {
    return this.gameService.getAllGames().subscribe((games: Game[]) => this.allGames = games);
  }

  ngOnInit(): void {
    this.getAllGames();
  }

}
