import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { Hero } from '../hero';
import { HeroService } from '../services/hero.service';

@Component({
  selector: 'app-hero-search',
  templateUrl: './hero-search.component.html',
  styleUrls: ['./hero-search.component.css'],
})
export class HeroSearchComponent implements OnInit {

  constructor(private heroService: HeroService) {}

  heroes$!: Observable<Hero[]>;
  private searchTerms = new Subject<string>();

  search(term: string): void {
    this.searchTerms.next(term);
  }

  ngOnInit(): void {
    this.heroes$ = this.searchTerms.pipe(
      debounceTime(300), // 傳出最終字串之前，debounceTime(300) 將會等待，直到新增字串的事件暫停了 300 毫秒

      distinctUntilChanged(), // ignore new term if same as previous term(確保只在過濾條件變化時才傳送請求)

      switchMap((term: string) => this.heroService.searchHeroes(term)) // 為每個從 debounce() 和 distinctUntilChanged() 中透過的搜尋詞調用搜索服務。 它會取消並丟棄以前的搜尋可觀察物件，只保留最近的
    );
  }
}
