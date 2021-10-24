import { inject } from 'aurelia-dependency-injection';
import { DialogService } from "aurelia-dialog";
import { ConfirmModel } from 'elements/models/confirm.model';
import { UserModel } from "elements/models/user.model";
import { UserService } from "elements/services/data-services/user.service";
import { ConfirmComponent } from 'elements/shared/confirm-component';
import { UserAsset } from '../user-asset/user-asset';
import { CreateUser } from './post/create-user';
import { EditUser } from './put/edit-user';

@inject(UserService, DialogService)
export class User
{
  users: Array<UserModel> = [];
  constructor(private service: UserService, private dialogService: DialogService) { }

  created(): void
  {
    this.load();
  }

  load(): void
  {
    this.users = [];
    this.service.get().then(x =>
    {
      this.users = x.users;
    });
  }

  onEdit(user: UserModel): void
  {
    this.dialogService.open({ viewModel: EditUser, model: user, lock: true }).whenClosed(response =>
    {
      if (!response.wasCancelled)
      {
        this.load();
      }
    });
  }

  onAddNew(): void
  {
    this.dialogService.open({ viewModel: CreateUser, model: {}, lock: true }).whenClosed(response =>
    {
      if (!response.wasCancelled)
      {
        this.load();
      }
    });
  }

  onManageAsset(user: UserModel): void
  {
    this.dialogService.open({ viewModel: UserAsset, model: user.id, lock: true }).whenClosed(response =>
    {
      if (!response.wasCancelled)
      {
        //Successfully Done
      }
    });
  }

  onDelete(userId: number): void
  {
    const confirmModel = new ConfirmModel();
    confirmModel.title = "Delete User";
    confirmModel.detail = "Are you sure to remove user?";
    this.dialogService.open({ viewModel: ConfirmComponent, model: confirmModel, lock: true })
      .whenClosed(response =>
      {
        if (!response.wasCancelled)
        {
          this.service.delete(userId).then(() =>
          {
            this.load();
          });
        }
      });
  }
}
