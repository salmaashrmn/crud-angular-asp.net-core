import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Player } from "./player";

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private apiURL = "https://localhost:44331/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient) { }

  getPlayers(): Observable<Player[]> {
    return this.httpClient.get<Player[]>(`${this.apiURL}/Players`)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  getPlayer(id): Observable<Player> {
    return this.httpClient.get<Player>(`${this.apiURL}/Players/${id}`)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  createPlayer(player: Player): Observable<Player> {
    return this.httpClient.post<Player>(`${this.apiURL}/Players`, player, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  updatePlayer(id, player: Player): Observable<Player> {
    return this.httpClient.put<Player>(`${this.apiURL}/Players/${id}`, player, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  deletePlayer(id): Observable<void> {
    return this.httpClient.delete<void>(`${this.apiURL}/Players/${id}`, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  errorHandler(error): Observable<never> {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    
    return throwError(errorMessage);
  }
}
