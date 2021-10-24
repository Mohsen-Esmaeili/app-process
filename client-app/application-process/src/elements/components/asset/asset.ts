import { inject } from 'aurelia-dependency-injection';
import { DialogService } from 'aurelia-dialog';
import { Notification } from 'aurelia-notification';
import { AssetModel } from 'elements/models/asset.model';
import { ConfirmModel } from 'elements/models/confirm.model';
import { AssetService } from 'elements/services/data-services/asset.service';
import { ConfirmComponent } from 'elements/shared/confirm-component';
import { CreateAsset } from './post/create-asset';
import { EditAsset } from './put/edit-asset';

@inject(AssetService, DialogService, Notification)
export class Asset
{
  assets: Array<AssetModel> = [];
  constructor(private service: AssetService, private dialogService: DialogService, private notification: Notification) { }

  created()
  {
    this.load();
  }

  load()
  {
    this.assets = [];
    this.service.get().then(x =>
    {
      this.assets = x.assets;
    });
  }

  onEdit(asset: AssetModel)
  {
    this.dialogService.open({ viewModel: EditAsset, model: asset, lock: true }).whenClosed(response =>
    {
      if (!response.wasCancelled)
      {
        this.notification.success("Succeed!");
        console.log('good - ', response.output);
      }
    });
  }

  onAddNew()
  {
    this.dialogService.open({ viewModel: CreateAsset, model: {}, lock: true }).whenClosed(response =>
    {
      if (!response.wasCancelled)
      {
        this.notification.success("Succeed!");
        this.load();
      }
    });
  }

  onDelete(id: string)
  {
    const confirmModel = new ConfirmModel();
    confirmModel.title = "Delete Asset";
    confirmModel.detail = "Are you sure to remove asset?";
    this.dialogService.open({ viewModel: ConfirmComponent, model: confirmModel, lock: true })
      .whenClosed(response =>
      {
        if (!response.wasCancelled)
        {
          this.service.delete(id);
          const index = this.assets.findIndex(x => x.id === id);
          if (index > -1)
          {
            this.notification.success("Succeed!");
            this.assets.splice(index, 1);
          }
        }
      });
  }
}
