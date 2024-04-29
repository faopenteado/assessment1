import { Component, Input } from '@angular/core';
import { Expenses } from '../../../types';

@Component({
  selector: 'app-group-expenses',
  standalone: true,
  templateUrl: './group-expenses.component.html',
  styleUrl: './group-expenses.component.css',
})
export class GroupExpensesComponent {
  @Input() expense!: Expenses;

  formatDate(date: Date) {
    let dateAux: Date = new Date(date);
    let now: Date = new Date();

    return (
      dateAux.getDate() + '/' + dateAux.getMonth() + '/' + dateAux.getFullYear()
    );
  }

  calculateDiff(date: Date) {
    let d2: Date = new Date();
    let d1: Date = new Date(date);
    var timeDiff = d2.getTime() - d1.getTime();
    var diff = timeDiff / 1000;
    if (diff < 60) return Math.floor(diff) + ' seconds ago';

    diff = diff / 60;
    if (diff < 60) return Math.floor(diff) + ' minutes ago';

    diff = diff / 60;
    if (diff < 24) return Math.floor(diff) + ' hours ago';

    return Math.floor(diff) + ' days ago';
  }
}
