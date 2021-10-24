import { inject } from 'aurelia-dependency-injection';
import { DialogService } from 'aurelia-dialog';
import { AssetModel } from 'elements/models/asset.model';
import { ConfirmModel } from 'elements/models/confirm.model';
import { AssetService } from 'elements/services/data-services/asset.service';
import { ConfirmComponent } from 'elements/shared/confirm-component';
import { CreateAsset } from './post/create-asset';
import { EditAsset } from './put/edit-asset';

@inject(AssetService, DialogService)
export class Asset
{
  assets: Array<AssetModel> = [];
  constructor(private service: AssetService, private dialogService: DialogService) { }

  created(): void
  {
    this.load();
  }

  load(): void
  {
    this.assets = [];
    this.service.get().then(x =>
    {
      this.assets = x.assets;
    });
  }

  onEdit(asset: AssetModel): void
  {
    this.dialogService.open({ viewModel: EditAsset, model: asset, lock: true }).whenClosed(response =>
    {
      if (!response.wasCancelled)
      {
        this.load();
      }
    });
  }

  onAddNew(): void
  {
    this.dialogService.open({ viewModel: CreateAsset, model: {}, lock: true }).whenClosed(response =>
    {
      if (!response.wasCancelled)
      {
        this.load();
      }
    });
  }

  onDelete(id: string): void
  {
    const confirmModel = new ConfirmModel();
    confirmModel.title = "Delete Asset";
    confirmModel.detail = "Are you sure to remove asset?";
    this.dialogService.open({ viewModel: ConfirmComponent, model: confirmModel, lock: true })
      .whenClosed(response =>
      {
        if (!response.wasCancelled)
        {
          this.service.delete(id).then(() =>
          {
            this.load();
          });
        }
      });
  }
}
