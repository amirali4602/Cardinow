import { Component, Injectable, Input } from '@angular/core';
import { UserModel } from '../../../models/user.model';
import { CommonModule } from '@angular/common';
import { RelativeTimePipe } from "../../pipes/relative-time.pipe/relative-time.pipe";
import { HighlightActiveDirective } from '../../directives/highlight-active.directive';

@Component({
  selector: 'app-user-card',
  imports: [CommonModule, RelativeTimePipe,HighlightActiveDirective],
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.scss',
  standalone:true
})
export class UserCardComponent {
@Input() user!: UserModel;
}
