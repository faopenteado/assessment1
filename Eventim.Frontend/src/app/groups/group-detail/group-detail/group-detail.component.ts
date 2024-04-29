import { Component, Input, OnInit } from '@angular/core';
import { Balance, Expenses, Group, GroupPeople } from '../../../../types';
import { GroupPeopleService } from '../../../services/group-people.service';
import { ActivatedRoute } from '@angular/router';
import { GroupsService } from '../../../services/groups.service';
import { ExpensesService } from '../../../services/expenses.service';

@Component({
  selector: 'app-group-detail',
  templateUrl: './group-detail.component.html',
  styleUrl: './group-detail.component.css',
})
export class GroupDetailComponent implements OnInit {
  constructor(
    private groupPeopleService: GroupPeopleService,
    private groupService: GroupsService,
    private route: ActivatedRoute,
    private expensesService: ExpensesService
  ) {}

  groupId: number = 0;

  @Input() group: Group = {
    name: '',
    id: 0,
  };

  people: GroupPeople[] = [];
  expenses: Expenses[] = [];
  balance: Balance = {
    expensesBalance: [],
    total: 0,
    debts: [],
  };

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.groupId = params['id']; // Access the 'id' parameter from the URL
    });

    this.getGroup(this.groupId);
    this.getPeople(this.groupId);
    this.getExpenses(this.groupId);
    this.getBalance(this.groupId);
  }

  getPeople(id: number) {
    this.groupPeopleService.getPeopleOnGroup(this.groupId).subscribe({
      next: (data: any) => {
        this.people = data as GroupPeople[];
      },
      error: (error) => {
        alert(error.message);
      },
    });
  }

  getGroup(id: number) {
    this.groupService.getGroup(id, { page: 0, perPage: 150 }).subscribe({
      next: (data: Group) => {
        this.group = data;
      },
      error(err) {
        alert(err.message);
      },
    });
  }

  getExpenses(id: number) {
    this.expensesService.getExpensesByGroup(id).subscribe({
      next: (data: Expenses[]) => {
        this.expenses = data;
      },
      error(err) {
        alert(err.message);
      },
    });
  }

  getBalance(id: number) {
    this.expensesService.getBalanceByGroup(id).subscribe({
      next: (data: Balance) => {
        this.balance = data;
      },
      error(err) {
        alert(err.message);
      },
    });
  }
}
