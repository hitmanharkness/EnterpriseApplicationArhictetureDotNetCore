import { NgModule }       from '@angular/core';
import { CommonModule }   from '@angular/common';
import { MessageComponent } from './message/message.component';
import { HttpClient } from './httpclient/http-client.service';
import { MessageService } from './message/message.service';
import { Http, HttpModule } from '@angular/http';

@NgModule({
    imports: [
        CommonModule,
        HttpModule
    ],
    exports: [
        MessageComponent
    ],
    declarations: [
        MessageComponent
    ],
    providers: [
        MessageService,
        HttpClient
    ]
})

export class SharedModule {
}