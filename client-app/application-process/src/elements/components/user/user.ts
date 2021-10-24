import { inject } from 'aurelia-dependency-injection';
import { DialogService } from "aurelia-dialog";
import { Notification } from "aurelia-notification";
import { ConfirmModel } from 'elements/models/confirm.model';
import { UserModel } from "elements/models/user.model";
import { UserService } from "elements/services/data-services/user.service";
import { ConfirmComponent } from 'elements/shared/confirm-component';
import { UserAsset } from '../user-asset/user-asset';
import { CreateUser } from './post/create-user';
import { EditUser } from './put/edit-user';

@inject(UserService, DialogService, Notification)
export class User
{
  users: Array<UserModel> = [];
  constructor(private service: UserService, private dialogService: DialogService, private notification: Notification) { }

  created()
  {
    this.load();
  }

  load()
  {
    this.users = [];
    this.service.get().then(x =>
    {
      this.users = x.users;
    });
  }

  onEdit(user: UserModel)
  {
    this.dialogService.open({ viewModel: EditUser, model: user, lock: true }).whenClosed(response =>
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
    this.dialogService.open({ viewModel: CreateUser, model: {}, lock: true }).whenClosed(response =>
    {
      if (!response.wasCancelled)
      {
        this.notification.success("Succeed!");
        this.load();
      }
    });
  }

  onManageAsset(user: UserModel)
  {
    this.dialogService.open({ viewModel: UserAsset, model: user.id, lock: true }).whenClosed(response =>
    {
      if (!response.wasCancelled)
      {
        this.notification.success("Succeed!");
      }
    });
  }

  onDelete(userId: number)
  {
    const confirmModel = new ConfirmModel();
    confirmModel.title = "Delete User";
    confirmModel.detail = "Are you sure to remove user?";
    this.dialogService.open({ viewModel: ConfirmComponent, model: confirmModel, lock: true })
      .whenClosed(response =>
      {
        if (!response.wasCancelled)
        {
          this.service.delete(userId);
          const index = this.users.findIndex(x => x.id === userId);
          if (index > -1)
          {
            this.notification.success("Succeed!");
            this.users.splice(index, 1);
          }
        }
      });
  }
}
