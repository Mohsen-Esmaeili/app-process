import { bindable, bindingMode } from 'aurelia-framework';

export class HeaderLayout
{
  activeRoute: string = '';
  @bindable({ defaultBindingMode: bindingMode.twoWay }) routerConfig;

  routerConfigChanged(newValue, oldValue)
  {
    this.activeRoute = newValue.name;
  }
}
