import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { PaginationParams, Group, GroupPeople } from '../../types';

@Injectable({
  providedIn: 'root',
})
export class GroupPeopleService {
  constructor(private apiService: ApiService) {}

  addGroupPeople = (body: any): Observable<any> => {
    return this.apiService.post('ExpensesGroupsPeople', body, {});
  };

  getPeopleOnGroup = (idGroup: number): Observable<GroupPeople> => {
    return this.apiService.get(
      'ExpensesGroupsPeople/GetPeopleInGroup/' + idGroup,
      {}
    );
  };
}
