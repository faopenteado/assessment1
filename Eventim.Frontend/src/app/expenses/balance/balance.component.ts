import { Component, Input } from '@angular/core';
import { Balance } from '../../../types';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-balance',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './balance.component.html',
  styleUrl: './balance.component.css',
})
export class BalanceComponent {
  @Input() balance!: Balance;
}
