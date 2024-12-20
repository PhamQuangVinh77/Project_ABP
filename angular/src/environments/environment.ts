import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Project_ABP',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44382/',
    redirectUri: baseUrl,
    clientId: 'Project_ABP_App',
    responseType: 'code',
    scope: 'offline_access Project_ABP',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44382',
      rootNamespace: 'Project_ABP',
    },
  },
} as Environment;
