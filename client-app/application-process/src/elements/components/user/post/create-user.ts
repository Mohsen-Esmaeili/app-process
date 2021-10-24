import { inject } from 'aurelia-dependency-injection';
import { DialogController } from "aurelia-dialog";
import { PostUserRequest } from "elements/models/data-model/post-user-request.model";
import { UserModel } from "elements/models/user.model";
import { UserService } from "elements/services/data-services/user.service";

@inject(UserService, DialogController)
export class CreateUser
{
  user: UserModel = new UserModel();

  constructor(private service: UserService, private controller: DialogController) { }

  submit(): void
  {
    const request = new PostUserRequest();
    request.FirstName = this.user.firstName;
    request.LastName = this.user.lastName;
    request.Age = this.user.age;
    request.Email = this.user.email;
    request.HouseNumber = this.user.houseNumber;
    request.PostalCode = this.user.postalCode;
    request.Street = this.user.street;

    this.service.post(request).then(() =>
    {
      this.controller.ok();
    });
  }
}
