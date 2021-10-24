import { inject } from 'aurelia-dependency-injection';
import { PostUserRequest } from 'elements/models/data-model/post-user-request.model';
import { PutUserRequest } from 'elements/models/data-model/put-user-request.model';
import { ApiService } from '../api.service';

@inject(ApiService)
export class UserService
{
  constructor(private apiService: ApiService) { }

  get(): any
  {
    return this.apiService.get('/user')
      .then(data => { return data; });
  }

  post(request: PostUserRequest): any
  {
    this.apiService.post('/user', request)
      .then(data => { return data; });
  }

  put(request: PutUserRequest): any
  {
    this.apiService.put('/user', request)
      .then(data => data);
  }

  delete(id: number): any
  {
    this.apiService.delete(`/user?Id=${ id }`)
      .then(data => data);
  }
}
