import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddPeopleOnGroupRoutingModule } from './add-people-on-group-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddPeopleOnGroupComponent } from './add-people-on-group/add-people-on-group.component';

@NgModule({
  declarations: [AddPeopleOnGroupComponent],
  imports: [
    CommonModule,
    AddPeopleOnGroupRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
export class AddPeopleOnGroupModule {}
