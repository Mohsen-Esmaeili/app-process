import { inject } from 'aurelia-dependency-injection';
import { PostAssetRequest } from 'elements/models/data-model/post-asset-request.model';
import { PutAssetRequest } from 'elements/models/data-model/put-asset-request.model';
import { ApiService } from '../api.service';

@inject(ApiService)
export class AssetService
{
  constructor(private apiService: ApiService) { }

  get(): Promise<any>
  {
    return this.apiService.get('/asset');
  }

  post(request: PostAssetRequest): Promise<any>
  {
    return this.apiService.post('/asset', request);
  }

  put(request: PutAssetRequest): Promise<any>
  {
    return this.apiService.put('/asset', request);
  }

  delete(id: string): Promise<any>
  {
    return this.apiService.delete(`/asset?AssetId=${ id }`);
  }
}
