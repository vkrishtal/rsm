import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { System } from '../../models/system';

import { environment } from '../../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class SystemService {
    private _system: Observable<System>;

    constructor(private _http: HttpClient) {
        this._system = this._http.get<System>(`${environment.api}/system`);
    }

    public get System() {
        return this._system;
    }
}
