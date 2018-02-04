import { Injectable } from '@angular/core';


@Injectable()
export class MessageService {

    public alerts: Array<Object> = [];

    pushMessage(message: MessageModel) {
        this.alerts.push(message);
    }

    pushMessages(messages: MessageModel[]) {
        this.alerts.push(messages);
    }

    clearMessages() {
        this.alerts = [];
    }


}

export class MessageModel {

    type: string;
    msg: string;

    constructor(type: string, message: string) {
        if (type == 'E')
            type = 'danger';
        else if (type == 'S')
            type = 'success';

        this.type = type;
        this.msg = message;
    }
}
