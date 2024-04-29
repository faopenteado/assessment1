import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { Balance, Expenses } from '../../types';

@Injectable({
  providedIn: 'root',
})
export class ExpensesService {
  constructor(private apiService: ApiService) {}

  addExpense = (body: any): Observable<Expenses> => {
    return this.apiService.post('Expenses', body, {});
  };

  getExpensesByGroup = (idGroup: number): Observable<Expenses[]> => {
    return this.apiService.get('Expenses/GetExpensesByGroup/' + idGroup, {});
  };

  getBalanceByGroup = (idGroup: number): Observable<Balance> => {
    return this.apiService.get('Expenses/GetBalanceByGroup/' + idGroup, {});
  };
}
