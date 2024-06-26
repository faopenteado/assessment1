import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddGroupRoutingModule } from './add-group-routing.module';
import { AddGroupComponent } from './add-group/add-group.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [AddGroupComponent],
  imports: [
    CommonModule,
    AddGroupRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [],
  providers: [],
})
export class AddGroupModule {}
