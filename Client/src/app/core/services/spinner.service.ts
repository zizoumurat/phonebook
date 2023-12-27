import { Injectable, NgZone } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpinnerService {

  visibility = new BehaviorSubject(false);

  constructor(private zone: NgZone) {
  }

  show() {
    setTimeout(() => {
      this.visibility.next(true);
    });
  }

  hide() {
    setTimeout(() => {
      this.visibility.next(false);
    });
  }
}
