import { Directive, Input, HostBinding } from '@angular/core';

@Directive({
  selector: '[appHighlightActiveDirective]',
  standalone: true
})
export class HighlightActiveDirective {

  @Input() isActive = false;

  @HostBinding('style.border-left')
  get border() {
    return this.isActive ? '5px solid #28a745' : '5px solid #dc3545';
  }
}
