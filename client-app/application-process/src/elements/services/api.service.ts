import { inject } from 'aurelia-dependency-injection';
import { HttpClient, json } from 'aurelia-fetch-client';
import { config } from './config';
import { parseError, status } from './servicehelper';

@inject(HttpClient)
export class ApiService
{
  constructor(private http: HttpClient) { }

  setHeaders()
  {
    const headersConfig = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    };

    return new Headers(headersConfig);
  }

  get(path: string)
  {
    const options = {
      method: 'get',
      headers: this.setHeaders()
    };

    return this.http.fetch(`${ config.api_url }${ path }`, options)
      .then(status)
      .catch(parseError);
  }

  put(path: string, body: any)
  {
    const options = {
      method: 'put',
      headers: this.setHeaders(),
      body: json(body)
    };
    return this.http.fetch(`${ config.api_url }${ path }`, options)
      .then(status)
      .catch(parseError);
  }

  post(path: string, body: any)
  {
    const options = {
      method: 'post',
      headers: this.setHeaders(),
      body: json(body)
    };
    return this.http.fetch(`${ config.api_url }${ path }`, options);
  }

  delete(path: string)
  {
    const options = {
      method: 'delete',
      headers: this.setHeaders()
    };

    return this.http.fetch(`${ config.api_url }${ path }`, options)
      .then(status)
      .catch(parseError);
  }
}
