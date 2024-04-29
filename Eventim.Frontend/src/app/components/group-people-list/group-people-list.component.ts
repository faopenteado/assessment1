import { Component, Input } from '@angular/core';
import { GroupPeople } from '../../../types';

@Component({
  selector: 'app-group-people-list',
  standalone: true,
  imports: [],
  templateUrl: './group-people-list.component.html',
  styleUrl: './group-people-list.component.css',
})
export class GroupPeopleListComponent {
  @Input() groupPeople!: GroupPeople;
}
