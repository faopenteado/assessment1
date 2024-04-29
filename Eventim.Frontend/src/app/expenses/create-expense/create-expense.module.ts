import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateExpenseRoutingModule } from './create-expense-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreateExpenseComponent } from './create-expense/create-expense.component';

@NgModule({
  declarations: [CreateExpenseComponent],
  imports: [
    CommonModule,
    CreateExpenseRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
export class CreateExpenseModule {}
