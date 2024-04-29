import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Options } from '../../types';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  constructor(private httpClient: HttpClient) {}
  baseUrl: string = 'https://localhost:32768/api/';

  // Used to make a GET request to the API
  get<T>(endpoint: string, options: Options): Observable<T> {
    return this.httpClient.get<T>(
      this.baseUrl + endpoint,
      options
    ) as Observable<T>;
  }

  // Used to make a POST request to the API
  post<T>(endpoint: string, body: T, options: Options): Observable<T> {
    return this.httpClient.post<T>(
      this.baseUrl + endpoint,
      body,
      options
    ) as Observable<T>;
  }

  // Used to make a PUT request to the API
  put<T>(endpoint: string, body: T, options: Options): Observable<T> {
    return this.httpClient.put<T>(
      this.baseUrl + endpoint,
      body,
      options
    ) as Observable<T>;
  }

  // Used to make a DELETE request to the API
  delete<T>(endpoint: string, options: Options): Observable<T> {
    return this.httpClient.delete<T>(
      this.baseUrl + endpoint,
      options
    ) as Observable<T>;
  }
}
