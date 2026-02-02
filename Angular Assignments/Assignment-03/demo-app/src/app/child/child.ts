import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-child',
  imports: [FormsModule],
  templateUrl: './child.html',
  styleUrl: './child.css',
})
export class Child {

  @Input() childName: string = '';
  @Input() childAge: number = 0;

  @Output() sendMessage = new EventEmitter<string>();

  childMessage: string = '';

  sendDataToParent() {
    this.sendMessage.emit(this.childMessage);
  }
}
