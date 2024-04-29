import { NgModule } from '@angular/core';
import { CommonModule, DATE_PIPE_DEFAULT_OPTIONS } from '@angular/common';
import { GroupPeopleListComponent } from '../../components/group-people-list/group-people-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GroupDetailComponent } from './group-detail/group-detail.component';
import { GroupDetailRoutingModule } from './group-detail-routing.module';
import { GroupExpensesComponent } from '../../components/group-expenses/group-expenses.component';
import { BalanceComponent } from '../../expenses/balance/balance.component';
import { DebtsComponent } from '../../expenses/debts/debts.component';

@NgModule({
  declarations: [GroupDetailComponent],
  imports: [
    CommonModule,
    GroupDetailRoutingModule,
    GroupPeopleListComponent,
    FormsModule,
    ReactiveFormsModule,
    GroupExpensesComponent,
    BalanceComponent,
    DebtsComponent,
  ],
})
export class GroupDetailModule {}
