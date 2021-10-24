import { DialogController } from 'aurelia-dialog';
import { inject } from 'aurelia-framework';
import { AssetModel } from 'elements/models/asset.model';
import { GetUserAssetResponse } from 'elements/models/data-model/get-user-asset-response.model';
import { PostUserAssetRequest } from 'elements/models/data-model/post-user-asset-request.model';
import { AssetService } from 'elements/services/data-services/asset.service';
import { UserAssetService } from 'elements/services/data-services/user-asset.service';

@inject(UserAssetService, AssetService, DialogController)
export class UserAsset
{
  userId: number;
  userAssets: Array<GetUserAssetResponse> = [];
  allAssets: Array<AssetModel> = [];
  selectedAssetId: string;

  constructor(private service: UserAssetService, private assetService: AssetService, private controller: DialogController) { }

  activate(userId: number)
  {
    this.userId = userId;
    this.loadByUserId();
    this.loadAllAssets();
  }

  loadAllAssets()
  {
    this.allAssets = [];
    this.assetService.get().then(response => this.allAssets = response.assets);
  }

  loadByUserId()
  {
    this.userAssets = [];
    this.service.get(this.userId).then(response =>
    {
      this.userAssets = response.userAssets;
    });
  }

  onAdd()
  {
    if (!this.selectedAssetId)
    {
      return;
    }

    const request = new PostUserAssetRequest();
    request.UserId = this.userId;
    request.AssetId = this.selectedAssetId;

    this.service.post(request);

    this.loadByUserId();
  }

  onDelete(id: number)
  {
    this.service.delete(id);
    this.loadByUserId();
  }
}
