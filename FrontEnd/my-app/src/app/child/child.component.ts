import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css'],
})
export class ChildComponent implements OnInit {
  @Output() public parentFunctionEvent = new EventEmitter<any>();
  constructor() {}

  ngOnInit() {}
  sendData() {
    this.parentFunctionEvent.emit('Clicked Footer Message');
  }
}
