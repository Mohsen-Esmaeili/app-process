import { DialogController } from 'aurelia-dialog';
import { inject } from 'aurelia-framework';
import { ConfirmModel } from 'elements/models/confirm.model';

@inject(DialogController)
export class ConfirmComponent
{
  info: ConfirmModel = {
    title: "Confirmation",
    detail: "Are you sure?"
  };

  constructor(private controller: DialogController) { }

  activate(info: ConfirmModel)
  {
    this.info = info;
  }
}
