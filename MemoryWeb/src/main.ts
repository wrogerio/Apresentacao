import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}

const providers = [
  { provide: 'API_URL', useValue: 'https://localhost:5001/api' },
  { provide: 'URL_BASE', useValue: 'http://localhost:4200' },
];

platformBrowserDynamic(providers)
  .bootstrapModule(AppModule)
  .catch((err) => console.error(err));
