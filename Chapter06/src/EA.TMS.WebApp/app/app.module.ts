
import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { APP_BASE_HREF } from '@angular/common';
import { AppComponent }   from './app.component';
import {MenuComponent} from './menu.component';
import { routing } from './app.routes';
import { ServiceRequestComponent } from './components/tenant/service-request.component';
import { SharedModule } from './shared/shared.module';
import { APP_CONFIG, TMS_DI_CONFIG } from './app.config';
import {FormsModule} from '@angular/forms';
import {ServiceRequestService} from './components/tenant/service-request.service';


@NgModule({
    imports: [
        BrowserModule,
        routing,
        SharedModule,
        FormsModule
    ],
    declarations: [
        AppComponent,
        ServiceRequestComponent,
        MenuComponent
    ],
    bootstrap: [AppComponent],
    providers: [
        { provide: APP_BASE_HREF, useValue: '/' },
        { provide: APP_CONFIG, useValue: TMS_DI_CONFIG },
        ServiceRequestService
    ]
})
export class AppModule { }