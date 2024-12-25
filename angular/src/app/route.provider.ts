import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/management',
        name: '::Menu:Management',
        iconClass: 'fa fa-pencil-square',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/manage-tinh',
        name: '::Menu:Tinh',
        parentName: '::Menu:Management',
        layout: eLayoutType.application,
      },
      {
        path: '/manage-huyen',
        name: '::Menu:Huyen',
        parentName: '::Menu:Management',
        layout: eLayoutType.application,
      },
    ]);
  };
}
