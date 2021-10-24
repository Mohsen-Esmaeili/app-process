import { inject } from 'aurelia-dependency-injection';
import { PostUserAssetRequest } from 'elements/models/data-model/post-user-asset-request.model';
import { ApiService } from '../api.service';

@inject(ApiService)
export class UserAssetService
{
  constructor(private apiService: ApiService) { }

  get(userId: number): Promise<any>
  {
    return this.apiService.get(`/UserAsset?UserId=${ userId }`);
  }

  post(request: PostUserAssetRequest): Promise<any>
  {
    return this.apiService.post('/UserAsset', request);
  }

  delete(id: number): Promise<any>
  {
    return this.apiService.delete(`/UserAsset?Id=${ id }`);
  }
}
