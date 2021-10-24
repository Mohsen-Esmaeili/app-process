import { DialogController } from 'aurelia-dialog';
import { inject } from 'aurelia-framework';
import { AssetModel } from 'elements/models/asset.model';
import { PutAssetRequest } from 'elements/models/data-model/put-asset-request.model';
import { AssetService } from 'elements/services/data-services/asset.service';

@inject(AssetService, DialogController)
export class EditAsset
{
  asset: AssetModel;


  constructor(private service: AssetService, private controller: DialogController) { }

  activate(asset: AssetModel)
  {
    this.asset = asset;
  }

  submit()
  {
    const request = new PutAssetRequest();
    request.Id = this.asset.id;
    request.Name = this.asset.name;
    request.Symbol = this.asset.symbol;

    this.service.put(request);
    this.controller.ok();
  }
}
