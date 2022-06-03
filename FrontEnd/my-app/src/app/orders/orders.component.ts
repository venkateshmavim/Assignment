import { Component, OnInit } from '@angular/core';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css'],
})
export class OrdersComponent implements OnInit {
  orders: any;
  constructor(private service: OrdersService) {}

  ngOnInit() {
    this.getPosts();
    console.log(this.orders);
  }
  private getPosts() {
    this.service.getposts().subscribe((resposne) => {
      this.orders = resposne;
    });
  }
}
