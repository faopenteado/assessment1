import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateExpenseComponent } from './create-expense/create-expense.component';

const routes: Routes = [
  // Home route
  {
    path: '',
    component: CreateExpenseComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CreateExpenseRoutingModule {}
