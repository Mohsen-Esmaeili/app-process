import { PLATFORM } from 'aurelia-pal';
import { Router, RouterConfiguration } from 'aurelia-router';

export class App
{
  router: Router;

  configureRouter(config: RouterConfiguration, router: Router)
  {
    config.title = "Application Process";
    config.options.pushState = true;
    config.options.root = "/";
    config.map([
      { route: '', name: 'home', moduleId: PLATFORM.moduleName('elements/components/home'), title: 'Home' },
      { route: 'user', name: 'user', moduleId: PLATFORM.moduleName('elements/components/user/user'), title: 'User' },
      { route: 'asset', name: 'asset', moduleId: PLATFORM.moduleName('elements/components/asset/asset'), title: 'Asset' }
    ]);

    this.router = router;
  }
}
