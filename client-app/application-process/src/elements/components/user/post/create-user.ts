import { inject, NewInstance } from 'aurelia-dependency-injection';
import { DialogController } from "aurelia-dialog";
import { ValidationController, ValidationRules } from 'aurelia-validation';
import { PostUserRequest } from "elements/models/data-model/post-user-request.model";
import { UserModel } from "elements/models/user.model";
import { UserService } from "elements/services/data-services/user.service";

@inject(UserService, DialogController, NewInstance.of(ValidationController))
export class CreateUser
{
  user: UserModel = new UserModel();

  constructor(private service: UserService, private dialogController: DialogController, private controller: ValidationController)
  {
    ValidationRules
      .ensure((m: UserModel) => m.firstName).displayName("First name").required().minLength(3).maxLength(50).withMessage("FirstName must has at least 3 characters.")
      .ensure((m: UserModel) => m.lastName).displayName("Last name").required().minLength(3).maxLength(50).withMessage("LastName must has at least 3 characters.")
      .ensure((m: UserModel) => m.email).displayName("Email").required().email().withMessage("Please specify a valid email.")
      .ensure((m: UserModel) => m.age).displayName("Age").required().min(19).withMessage("Age must be greater than 18.")
      .ensure((m: UserModel) => m.street).displayName("Street").required().withMessage("Street is required.")
      .ensure((m: UserModel) => m.postalCode).displayName("Postal code").required().withMessage("Postal code is required.")
      .ensure((m: UserModel) => m.houseNumber).displayName("House number").required().withMessage("House number is required")
      .on(UserModel);
  }

  submit(): void
  {
    this.controller.validate().then((res) =>
    {
      if (res.valid)
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
          this.dialogController.ok();
        });
      }
    });
  }
}
