import { inject, NewInstance } from 'aurelia-dependency-injection';
import { DialogController } from 'aurelia-dialog';
import { ValidationController, ValidationRules } from 'aurelia-validation';
import { AssetModel } from 'elements/models/asset.model';
import { PostAssetRequest } from 'elements/models/data-model/post-asset-request.model';
import { AssetService } from 'elements/services/data-services/asset.service';

@inject(AssetService, DialogController, NewInstance.of(ValidationController))
export class CreateAsset
{
  asset: AssetModel = new AssetModel();

  constructor(private service: AssetService, private dialogController: DialogController, private controller: ValidationController)
  {
    ValidationRules
      .ensure((m: AssetModel) => m.name).displayName("Name").required().withMessage("Asset name is required")
      .ensure((m: AssetModel) => m.symbol).displayName("Symbol").required().withMessage("Asset symbol is required")
      .on(AssetModel);
  }

  submit(): void
  {
    this.controller.validate().then((res) =>
    {
      if (res.valid)
      {
        const request = new PostAssetRequest();
        request.Name = this.asset.name;
        request.Symbol = this.asset.symbol;

        this.service.post(request).then(() =>
        {
          this.dialogController.ok();
        });
      }
    });
  }
}
