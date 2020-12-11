import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import * as signalr from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  capacity: number = 0;
  private capacityhub: signalr.HubConnection;

  constructor(private http: HttpClient) {
    this.capacityhub = new signalr.HubConnectionBuilder()
      .withUrl("http://localhost/capacityhub")
      .build(); 

    this.capacityhub.start().catch(err => console.log(err));
    this.capacityhub.on("capacityupdate", (data) => this.capacity = data);
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
      .subscribe(x => {});
  }

  decrease(){
    this.http
      .post("http://localhost/api/capacity/decrease", {})
      .subscribe(x => {});
  }
}