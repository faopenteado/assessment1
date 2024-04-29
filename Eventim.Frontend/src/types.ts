import { HttpContext, HttpHeaders, HttpParams } from '@angular/common/http';

export interface Options {
  headers?:
    | HttpHeaders
    | {
        [header: string]: string | string[];
      };
  observe?: 'body';
  context?: HttpContext;
  params?:
    | HttpParams
    | {
        [param: string]:
          | string
          | number
          | boolean
          | ReadonlyArray<string | number | boolean>;
      };
  reportProgress?: boolean;
  responseType?: 'json';
  withCredentials?: boolean;
  transferCache?:
    | {
        includeHeaders?: string[];
      }
    | boolean;
}

export interface Group {
  name: string;
  id?: number;
}

export interface GroupPeople {
  name: string;
  id?: number;
  expensesGroupId?: number;
}

export interface Expenses {
  expensesGroupPeopleId: number;
  expensesGroupsId: number;
  peopleName: string;
  expensesGroupsName: string;
  id: number;
  description: string;
  amount: number;
  date: Date;
}

export interface ExpensesBalance {
  amount: number;
  personName: string;
}

export interface Debt {
  personToPay: string;
  personToReceive: string;
  amountToPay: number;
}

export interface Balance {
  total: number;
  expensesBalance: ExpensesBalance[];
  debts: Debt[];
}

export interface PaginationParams {
  [param: string]:
    | string
    | number
    | boolean
    | ReadonlyArray<string | number | boolean>;
  page: number;
  perPage: number;
}
