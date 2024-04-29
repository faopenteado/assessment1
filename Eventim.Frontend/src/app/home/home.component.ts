import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GrouplistComponent } from '../components/grouplist/grouplist.component';
import { Group } from '../../types';
import { GroupsService } from '../services/groups.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, GrouplistComponent, RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  constructor(private groupsService: GroupsService) {}

  groups: Group[] = [];

  getGroups() {
    this.groupsService.getGroups({ page: 0, perPage: 100 }).subscribe({
      next: (data: Group[]) => {
        this.groups = data;
      },
      error: (error) => {
        console.log(error);
        alert(error.message);
      },
    });
  }

  ngOnInit() {
    this.getGroups();
  }
}
