import { inject } from 'aurelia-dependency-injection';
import { PostUserAssetRequest } from 'elements/models/data-model/post-user-asset-request.model';
import { ApiService } from '../api.service';

@inject(ApiService)
export class UserAssetService
{
  constructor(private apiService: ApiService) { }

  get(userId: number): any
  {
    return this.apiService.get(`/UserAsset?UserId=${ userId }`)
      .then(data => { return data; });
  }

  post(request: PostUserAssetRequest): any
  {
    this.apiService.post('/UserAsset', request)
      .then(data => { return data; });
  }

  delete(id: number): any
  {
    this.apiService.delete(`/UserAsset?Id=${ id }`)
      .then(data => data);
  }
}
