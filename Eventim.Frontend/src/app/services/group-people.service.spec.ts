import { TestBed } from '@angular/core/testing';

import { GroupPeopleService } from './group-people.service';

describe('GroupsService', () => {
  let service: GroupPeopleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GroupPeopleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
