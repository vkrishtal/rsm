import { Injectable } from '@angular/core';
import { Process } from '../../models/process';
import { HttpClient } from '@angular/common/http';

import { Observable, interval } from 'rxjs';
import { flatMap, tap, repeat, filter } from 'rxjs/operators';

import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProcessService {

  // private _processes: Observable<Process>;

  private _processes: Observable<Process[]>;

  get Processes(): Observable<Process[]> {
    return this._processes;
  }

  constructor(private _http: HttpClient) {

    this._processes = this._http
      .get<Process[]>(`${environment.api}/process`)
      .pipe(repeat());
  }
}
