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

  activate(userId: number): void
  {
    this.userId = userId;
    this.load();
  }

  load(): void
  {
    this.userAssets = [];
    this.service.get(this.userId).then(response =>
    {
      this.userAssets = response.userAssets;
      this.allAssets = [];
      this.assetService.get().then(assetsResponse =>
      {
        const existsAssets = response.userAssets.map(userAsset => userAsset.assetId);
        assetsResponse.assets.forEach(asset =>
        {
          if (!existsAssets.includes(asset.id))
          {
            this.allAssets.push(asset);
          }
        });
      });

    });
  }

  onAdd(): void
  {
    if (!this.selectedAssetId)
    {
      return;
    }

    const request = new PostUserAssetRequest();
    request.UserId = this.userId;
    request.AssetId = this.selectedAssetId;

    this.service.post(request).then(() =>
    {
      this.load();
    });
  }

  onDelete(id: number): void
  {
    this.service.delete(id).then(() =>
    {
      this.load();
    });
  }
}
