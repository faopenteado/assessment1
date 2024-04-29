import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupPeopleListComponent } from './group-people-list.component';

describe('GroupPeopleListComponent', () => {
  let component: GroupPeopleListComponent;
  let fixture: ComponentFixture<GroupPeopleListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GroupPeopleListComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(GroupPeopleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
