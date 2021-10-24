import { DialogController } from 'aurelia-dialog';
import { inject } from 'aurelia-framework';
import { Notification } from 'aurelia-notification';
import { AssetModel } from 'elements/models/asset.model';
import { PostAssetRequest } from 'elements/models/data-model/post-asset-request.model';
import { AssetService } from 'elements/services/data-services/asset.service';

@inject(AssetService, DialogController, Notification)
export class CreateAsset
{
  asset: AssetModel = new AssetModel();

  constructor(private service: AssetService, private controller: DialogController, private notification: Notification) { }

  submit()
  {
    const request = new PostAssetRequest();
    request.Name = this.asset.name;
    request.Symbol = this.asset.symbol;

    this.service.post(request).then(() =>
    {
      debugger;
    });
    this.controller.ok();

    this.notification.success("Asset is added!");
  }
}
