import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  capacity: number = 0;

  constructor(private http: HttpClient) {    
  }

  ngOnInit(){
    this.load();
  }

  load() {
    this.http
      .get<number>("http://localhost/api/capacity")
      .subscribe(x => this.capacity = x);
  }

  increase(){
    this.http
      .post("http://localhost/api/capacity/increase", {})
      .subscribe(x => this.load());
  }

  decrease(){
    this.http
      .post("http://localhost/api/capacity/decrease", {})
      .subscribe(x => this.load());    
  }
}
