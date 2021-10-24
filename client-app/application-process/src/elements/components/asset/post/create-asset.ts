import { DialogController } from 'aurelia-dialog';
import { inject } from 'aurelia-framework';
import { AssetModel } from 'elements/models/asset.model';
import { PostAssetRequest } from 'elements/models/data-model/post-asset-request.model';
import { AssetService } from 'elements/services/data-services/asset.service';

@inject(AssetService, DialogController)
export class CreateAsset
{
  asset: AssetModel = new AssetModel();

  constructor(private service: AssetService, private controller: DialogController) { }

  submit(): void
  {
    const request = new PostAssetRequest();
    request.Name = this.asset.name;
    request.Symbol = this.asset.symbol;

    this.service.post(request).then(() =>
    {
      this.controller.ok();
    });
  }
}
