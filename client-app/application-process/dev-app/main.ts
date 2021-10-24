import { Aurelia } from 'aurelia-framework';
import { PLATFORM } from 'aurelia-pal';
import environment from './environment';

export function configure(aurelia: Aurelia): void
{
  aurelia.use
    .standardConfiguration()
    .feature('resources')
    .plugin(PLATFORM.moduleName('aurelia-validation'))
    .plugin(PLATFORM.moduleName('aurelia-dialog'))
    .plugin('aurelia-notification', config =>
    {
      config.configure({
        translate: false,  // 'true' needs aurelia-i18n to be configured
        notifications: {
          'success': 'humane-libnotify-success',
          'error': 'humane-libnotify-error',
          'info': 'humane-libnotify-info'
        }
      });
    });
  // load the plugin ../src
  // The "resources" is mapped to "../src" in aurelia.json "paths"

  aurelia.use.developmentLogging(environment.debug ? 'debug' : 'warn');

  if (environment.testing)
  {
    aurelia.use.plugin('aurelia-testing');
  }

  aurelia.start().then(() => aurelia.setRoot());
}
