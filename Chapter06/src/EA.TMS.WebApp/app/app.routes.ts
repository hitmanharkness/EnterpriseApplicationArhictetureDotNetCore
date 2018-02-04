import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ServiceRequestComponent } from './components/tenant/service-request.component'
import { MenuComponent } from './menu.component'


//Routes Configuration
export const routes: Routes = [
    { path: 'createServiceRequest', component: ServiceRequestComponent },
    { path: 'menu', component: MenuComponent },
    {
        path: '',
        redirectTo: '/menu',
        pathMatch: 'full'
    },
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);

