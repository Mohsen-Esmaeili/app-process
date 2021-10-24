export class UserModel
{
  public id: number;
  public firstName: string;
  public lastName: string;
  public age: number;
  public email: string;
  public postalCode: string;
  public street: string;
  public houseNumber: number;
  public assets: Array<Asset> = [];
}

export class Asset
{
  public id: string;
  public name: string;
  public symbol: string;
}
