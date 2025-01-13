import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { Game } from 'src/app/models/game.model';
import { GamesService } from 'src/app/services/games.service';


@Component({
  selector: 'app-game-details',
  templateUrl: './game-details.component.html',
  styleUrls: ['./game-details.component.scss']
})
export class GameDetailsComponent implements OnInit {

  gameId : any;
  game : Game;

  constructor(private route: ActivatedRoute, private gameService : GamesService) { }

  ngOnInit(): void {
    this.gameId = this.route.snapshot.paramMap.get('id');
    console.log(this.gameId);
    this.gameService.getGameByIdWithDetails(this.gameId).subscribe((game: Game) => this.game = game);
  } 
  
}
