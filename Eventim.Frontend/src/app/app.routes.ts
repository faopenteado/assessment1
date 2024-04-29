import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'add-group',
    loadChildren: () =>
      import('./groups/add-group/add-group.module').then(
        (m) => m.AddGroupModule
      ),
  },
  {
    path: 'group-detail/:id',
    loadChildren: () =>
      import('./groups/group-detail/group-detail.module').then(
        (m) => m.GroupDetailModule
      ),
  },
  {
    path: 'add-people-on-group/:id',
    loadChildren: () =>
      import('./groups/add-people-on-group/add-people-on-group.module').then(
        (m) => m.AddPeopleOnGroupModule
      ),
  },
  {
    path: 'add-expense/:id',
    loadChildren: () =>
      import('./expenses/create-expense/create-expense.module').then(
        (m) => m.CreateExpenseModule
      ),
  },
];
