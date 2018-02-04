import { Component } from '@angular/core';
import { MessageService } from './message.service';
//<alert *ngFor="let alert of _messageService.alerts;let i = index"[type] = "alert.type" dismissible= "true"(close) = "closeAlert(i)" >
//    {{ alert ?.msg }}
//</alert>
@Component({
    selector: 'messages',
    template: `
                <div *ngFor="let alert of _messageService.alerts;let i = index">
                    {{ alert?.msg }}
                <button (click)="closeAlert(i)">Close</button>
                </div>`
})

export class MessageComponent {

    constructor(public _messageService: MessageService) {
    }

    public closeAlert(i: number): void {
        this._messageService.alerts.splice(i, 1);
    }
}
