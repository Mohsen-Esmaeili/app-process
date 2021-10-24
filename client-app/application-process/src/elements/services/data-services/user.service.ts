import { inject } from 'aurelia-dependency-injection';
import { PostUserRequest } from 'elements/models/data-model/post-user-request.model';
import { PutUserRequest } from 'elements/models/data-model/put-user-request.model';
import { ApiService } from '../api.service';

@inject(ApiService)
export class UserService
{
  constructor(private apiService: ApiService) { }

  get(): Promise<any>
  {
    return this.apiService.get('/user');
  }

  post(request: PostUserRequest): Promise<any>
  {
    return this.apiService.post('/user', request);
  }

  put(request: PutUserRequest): Promise<any>
  {
    return this.apiService.put('/user', request);
  }

  delete(id: number): Promise<any>
  {
    return this.apiService.delete(`/user?Id=${ id }`);
  }
}
