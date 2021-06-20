import { Injectable } from '@angular/core';
import { Hero } from '../hero';
import { HEROES } from '../mock-heroes';
import { Observable, of } from 'rxjs';
import { MessageService } from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})


export class HeroService {
  constructor(
    private messageService: MessageService,
    private http: HttpClient
  ) {}

  private log(message: string) {
    this.messageService.add(`英雄伺服器狀態: ${message}`);
  }

  private heroesUrl = 'api/heroes'; // URL to web api

  private handleError<T>(operation = 'operation', result?: T) {
    //Handle Http operation that failed，
    //operation - name of the operation that failed
    //result - optional value to return as the observable result

    return (error: any): Observable<T> => {
      console.error(error); // log to console instead，TODO: send the error to remote logging infrastructure

      this.log(`${operation} failed: ${error.message}`); // TODO: better job of transforming error for user consumption

      return of(result as T); // Let the app keep running by returning an empty result.
    };
  }

  /** 拿全部資料 */
  getHeroes(): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.heroesUrl).pipe(
      tap((_) => this.log('抽出整筆英雄數據')),
      catchError(this.handleError<Hero[]>('getHeroes', []))
    );
  }

  /** 拿個別資料 */
  getHero(id: number): Observable<Hero> {
    const url = `${this.heroesUrl}/${id}`;      //  資料伺服器位置：api / heroes / 數字;          
    return this.http.get<Hero>(url).pipe(
      tap((_) => this.log(`抽出某位英雄編號：${id}`)),
      catchError(this.handleError<Hero>(`getHero id=${id}`))
    );
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  /** 更新資料 */
  updateHero(hero: Hero): Observable<any> {
    return this.http.put(this.heroesUrl, hero, this.httpOptions).pipe(
      //HttpClient.put() 方法接受三個引數：URL 地址、要修改的資料（這裡就是修改後的英雄）、選項
      tap((_) => this.log(`更新某位英雄編號=${hero.id}`)),
      catchError(this.handleError<any>('updateHero'))
    );
  }

  /** 新增資料 */
  addHero(hero: Hero): Observable<Hero> {
    return this.http.post<Hero>(this.heroesUrl, hero, this.httpOptions).pipe(
      tap((newHero: Hero) => this.log(` 新增英雄 w/ id=${newHero.id}`)),
      catchError(this.handleError<Hero>('addHero'))
    );
  }

  /** 刪除資料*/
  deleteHero(id: number): Observable<Hero> {
    const url = `${this.heroesUrl}/${id}`;

    return this.http.delete<Hero>(url, this.httpOptions).pipe(
      tap((_) => this.log(`剔除某位英雄編號：${id}`)),
      catchError(this.handleError<Hero>('deleteHero'))
    );
  }

  /* 搜索 */
  searchHeroes(term: string): Observable<Hero[]> {
    if (!term.trim()) {
      return of([]);
    }
    return this.http.get<Hero[]>(`${this.heroesUrl}/?name=${term}`).pipe(
      tap((x) =>
        x.length
          ? this.log(`找到此為英雄 "${term}"`)
          : this.log(`沒有此為英雄 "${term}"`)
      ),
      catchError(this.handleError<Hero[]>('searchHeroes', []))
    );
  }
}

