import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Drive } from '../../models/drive';

import { environment } from '../../../../environments/environment';

@Injectable()
export class DriveService {
    private _drives: Observable<Drive[]>;

    constructor(private _http: HttpClient) {
        this._drives = _http.get<Drive[]>(`${environment.api}/drive`);
    }

    public get drives() {
        return this._drives;
    }
}
