import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appRequiredStar]',
  standalone: true
})
export class RequiredStarDirective {

  constructor(private el: ElementRef) {}

  ngDoCheck() {
    const label = this.el.nativeElement;

    const input = label.nextElementSibling?.nextElementSibling;

    if (!input) return;

    const isInvalid =
      input.classList.contains('ng-invalid') &&
      input.classList.contains('ng-touched');

    label.innerHTML = isInvalid ? 'Email <span style="color:red">**</span>' : 'Email';
  }
}
