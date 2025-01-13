import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GamesComponent } from '../games/games.component';
import { GamesService } from 'src/app/services/games.service';
import { HomeComponent } from './home.component';
import { GameDetailsComponent } from '../details/game-details.component';
import { RouterModule } from '@angular/router';
import { AboutComponent } from '../about/about.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { EditGameComponent } from '../edit-game/edit-game.component';

@NgModule({
  declarations: [GamesComponent, HomeComponent, GameDetailsComponent, EditGameComponent],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [HttpClient, GamesService ],
  exports: [GamesComponent, HomeComponent, GameDetailsComponent]
})
export class HomeModule { 

  constructor() { }

}
