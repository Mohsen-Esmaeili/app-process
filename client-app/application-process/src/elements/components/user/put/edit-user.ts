import { DialogController } from 'aurelia-dialog';
import { inject } from 'aurelia-framework';
import { PutUserRequest } from 'elements/models/data-model/put-user-request.model';
import { UserModel } from 'elements/models/user.model';
import { UserService } from 'elements/services/data-services/user.service';

@inject(UserService, DialogController)
export class EditUser
{
  user: UserModel;


  constructor(private service: UserService, private controller: DialogController) { }

  activate(user: UserModel)
  {
    this.user = user;
  }

  submit()
  {
    const request = new PutUserRequest();
    request.Id = this.user.id;
    request.FirstName = this.user.firstName;
    request.LastName = this.user.lastName;
    request.Age = this.user.age;
    request.Email = this.user.email;
    request.HouseNumber = this.user.houseNumber;
    request.PostalCode = this.user.postalCode;
    request.Street = this.user.street;

    this.service.put(request);
    this.controller.ok();
  }
}
