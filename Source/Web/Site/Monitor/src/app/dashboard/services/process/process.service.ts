import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
import { Process } from '../../models/process';

@Injectable({
  providedIn: 'root'
})
export class ProcessService {

  // private _processes: Observable<Process>;

  private _processes = new Subject<Process>();

  get Processes(): Observable<Process> {
    return this._processes;
  }

  constructor() {

    setInterval(() => {
      this._processes.next({
        name: 'process_name',
        pid: 'proccess_pid',
        status: 'running',
        user: 'vkrishtal'
      });
    }, 2000);
  }


}
