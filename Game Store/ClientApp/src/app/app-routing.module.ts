import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { CommunityComponent } from './components/community/community.component';
import { GameDetailsComponent } from './components/details/game-details.component';
import { HomeComponent } from './components/home/home.component';
import { SinginComponent } from './components/singin/singin.component';
import { SupportComponent } from './components/support/support.component';

const routes: Routes = [
  { path: "home",  component: HomeComponent },
  { path: "home/:id", component: GameDetailsComponent },
  { path: "", redirectTo: "home", pathMatch: "full"},
  { path: "community", component: CommunityComponent},
  { path: "about", component: AboutComponent},
  { path: "signin", component: SinginComponent},
  { path: "support", component: SupportComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
