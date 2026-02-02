import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RequiredStarDirective } from './directives/required-star';
import { EmailMaskPipe } from './pipes/email-mask-pipe';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,RequiredStarDirective,EmailMaskPipe,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  email = 'meetantala@gmail.com';
}
