import { Component, Input } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GroupPeople } from '../../../../types';
import { GroupPeopleService } from '../../../services/group-people.service';

@Component({
  selector: 'app-add-people-on-group',
  templateUrl: './add-people-on-group.component.html',
  styleUrl: './add-people-on-group.component.css',
})
export class AddPeopleOnGroupComponent {
  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router,
    private groupPeopleService: GroupPeopleService
  ) {}

  groupId: number = 0;

  @Input() people: GroupPeople = {
    name: '',
    expensesGroupId: this.groupId,
    id: 0,
  };

  peopleForm = this.formBuilder.group({
    name: ['', [Validators.required]],
  });

  onCancel() {
    this.router.navigate(['/group-detail/' + this.groupId]);
  }

  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.groupId = params['id']; // Access the 'id' parameter from the URL
    });
  }

  save() {
    this.people = this.peopleForm.value as GroupPeople;
    this.people.expensesGroupId = this.groupId;
    let a = 0;

    this.groupPeopleService.addGroupPeople(this.people).subscribe({
      next: (data: any) => {
        this.router.navigate(['/group-detail/' + this.groupId]);
      },
      error: (error) => {
        console.log(error.message);
        alert(error.message);
      },
    });
  }
}
