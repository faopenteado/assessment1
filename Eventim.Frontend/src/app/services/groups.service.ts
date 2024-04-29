import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { PaginationParams, Group } from '../../types';

@Injectable({
  providedIn: 'root',
})
export class GroupsService {
  constructor(private apiService: ApiService) {}

  // Getting grups from the API
  getGroups = (params: PaginationParams): Observable<Group[]> => {
    return this.apiService.get('ExpensesGroups', {});
  };

  // Getting groups from the API
  getGroup = (id: number, params: PaginationParams): Observable<Group> => {
    return this.apiService.get('ExpensesGroups/' + id, {});
  };

  // Adding a group via the API
  addGroup = (body: any): Observable<any> => {
    return this.apiService.post('ExpensesGroups', body, {});
  };

  // // Editing a product via the API
  // editProduct = (url: string, body: any): Observable<any> => {
  //   return this.apiService.put(url, body, {});
  // };

  // // Deleting a product via the API
  // deleteProduct = (url: string): Observable<any> => {
  //   return this.apiService.delete(url, {});
  // };
}
