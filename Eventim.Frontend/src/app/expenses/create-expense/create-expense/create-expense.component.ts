import { Component, Input } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ExpensesService } from '../../../services/expenses.service';
import { Expenses, GroupPeople } from '../../../../types';
import { getLocaleDateFormat } from '@angular/common';
import { GroupsService } from '../../../services/groups.service';
import { GroupPeopleService } from '../../../services/group-people.service';

@Component({
  selector: 'app-create-expense',
  templateUrl: './create-expense.component.html',
  styleUrl: './create-expense.component.css',
})
export class CreateExpenseComponent {
  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router,
    private expensesService: ExpensesService,
    private groupPeopleService: GroupPeopleService
  ) {}

  groupId: number = 0;
  people: GroupPeople[] = [];

  expenseForm = this.formBuilder.group({
    expensesGroupPeopleId: [0, [Validators.required]],
    description: ['', [Validators.required]],
    amount: [0, [Validators.required]],
  });

  @Input() expense: Expenses = {
    expensesGroupPeopleId: 0,
    expensesGroupsId: this.groupId,
    description: '',
    amount: 0,
    date: new Date(),
    expensesGroupsName: '',
    id: 0,
    peopleName: '',
  };

  onCancel() {
    this.router.navigate(['/group-detail/' + this.groupId]);
  }

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.groupId = params['id']; // Access the 'id' parameter from the URL
    });

    this.getPeople(this.groupId);
  }

  save() {
    this.expense = this.expenseForm.value as Expenses;
    this.expense.expensesGroupsId = this.groupId;
    this.expense.date = new Date();

    this.expensesService.addExpense(this.expense).subscribe({
      next: (data: any) => {
        this.router.navigate(['/group-detail/' + this.groupId]);
      },
      error: (error) => {
        console.log(error.message);
        alert(error.message);
      },
    });
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
}
