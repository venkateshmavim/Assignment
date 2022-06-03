import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  private url = 'https://localhost:7038/api/Orders/Get-Orders';
  constructor(private httpclient: HttpClient) {}

  getposts() {
    return this.httpclient.get(this.url, {
      headers: new HttpHeaders({
        Authorization: `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJzdWIiOiJUZXN0IGFwcGxpY2F0aW9uIG9mIG1hdmltIiwianRpIjoiMjlhZjBiNTctNmE3My00Nzk2LTljNGItZmI4OWYzYzNlZjk5IiwiaWF0IjoiMDMtMDYtMjAyMiAwMzo1NTo0MCIsIlVzZXJJZCI6IlJhc2hpZCIsIklzU3VwZXJBZG1pbiI6IjEiLCJleHAiOjE2NTQ0ODc3NDAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NzAzOCIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMCJ9.nZpW9mCltjkfYAdvp0UPj1xZGa6l5_BhZF8aQ1gpAaU`,
      }),
    });
  }
}
