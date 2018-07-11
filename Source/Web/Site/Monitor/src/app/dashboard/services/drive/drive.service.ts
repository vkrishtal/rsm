import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Drive } from '../../models/drive';

import { environment } from '../../../../environments/environment';
import { inject } from '@angular/core/testing';

@Injectable()
export class DriveService {
    private _drives: Observable<Drive[]>;

    constructor(private _http: HttpClient) {
        this._drives = _http.get<Drive[]>(`${environment.api}/drive`);
    }

    public get Drives() {
        return this._drives;
    }
}
