import { Component, Input } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Group } from '../../../../types';
import { Router } from '@angular/router';
import { GroupsService } from '../../../services/groups.service';

@Component({
  selector: 'app-add-group',
  templateUrl: './add-group.component.html',
  styleUrl: './add-group.component.css',
})
export class AddGroupComponent {
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private groupService: GroupsService
  ) {}

  @Input() group: Group = {
    name: '',
    id: 0,
  };

  groupForm = this.formBuilder.group({
    name: ['', [Validators.required]],
  });

  ngOnChanges() {
    this.groupForm.patchValue(this.group);
  }

  onCancel() {
    this.router.navigate(['/']);
  }

  save() {
    this.group = this.groupForm.value as Group;

    let a = 0;

    this.groupService.addGroup(this.group).subscribe({
      next: (data: any) => {
        this.router.navigate(['/']);
      },
      error: (error) => {
        console.log(error);
        alert(error);
      },
    });
  }
}
