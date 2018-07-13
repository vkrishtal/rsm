import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../../environments/environment';
import { Ram } from '../../models/ram';
import { Observable, interval } from 'rxjs';
import { map, filter, scan, tap, flatMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RamService {
  private _ram: Observable<Ram>;

  constructor(private _http: HttpClient) {
    this._ram = interval(800).pipe(
      flatMap(_ => _http.get<Ram>(`${environment.api}/ram`))
    );
  }

  public get ram(): Observable<Ram> {
    return this._ram;
  }
}
