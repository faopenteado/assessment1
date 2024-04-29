import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Group } from '../../../types';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-grouplist',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './grouplist.component.html',
  styleUrl: './grouplist.component.css',
})
export class GrouplistComponent {
  @Input() group!: Group;
  @Output() addExpense: EventEmitter<Group> = new EventEmitter<Group>();

  addExpenseOnGroup() {
    this.addExpense.emit(this.group);
  }
}
