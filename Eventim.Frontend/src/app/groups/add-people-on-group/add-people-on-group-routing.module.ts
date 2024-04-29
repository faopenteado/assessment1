import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPeopleOnGroupComponent } from './add-people-on-group/add-people-on-group.component';

const routes: Routes = [
  {
    path: '',
    component: AddPeopleOnGroupComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddPeopleOnGroupRoutingModule {}
