
import { OpaqueToken } from '@angular/core';

export let APP_CONFIG = new OpaqueToken('app.config');

export interface AppConfig {
    apiEndpoint: string;
    title: string;
    casEndPoint: string;
    appEndPoint: string;
}

export const TMS_DI_CONFIG: AppConfig = {
    apiEndpoint: 'http://localhost:5001/api/',
    title: 'TMS System',
    casEndPoint: 'http://localhost:5001',
    appEndPoint: 'http://localhost:5050'
};
