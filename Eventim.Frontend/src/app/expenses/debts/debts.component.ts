import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Debt } from '../../../types';

@Component({
  selector: 'app-debts',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './debts.component.html',
  styleUrl: './debts.component.css',
})
export class DebtsComponent {
  @Input() debts!: Debt[];
}
