import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-counter-n',
  templateUrl: './counter-n.component.html'
})
export class CounterNComponent implements OnInit {
  public userInput = 0;
  public currentCount = 0;

  constructor() { }

  ngOnInit() {
  }

  public incrementCounter() {
        this.currentCount += this.userInput;
  }

}
