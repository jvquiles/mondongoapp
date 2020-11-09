import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {

  capacity: number = 0;
  http: HttpClient;

  constructor(http: HttpClient ) { 
    this.http = http;
  }

  ngOnInit(): void {
    this.loadCapacity();
  }

  loadCapacity(){
    this.http.get<number>("http://api/api/capacity")
      .subscribe((data: number) => this.capacity = data);
  }
}