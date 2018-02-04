"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var MessageService = (function () {
    function MessageService() {
        this.alerts = [];
    }
    MessageService.prototype.pushMessage = function (message) {
        this.alerts.push(message);
    };
    MessageService.prototype.pushMessages = function (messages) {
        this.alerts.push(messages);
    };
    MessageService.prototype.clearMessages = function () {
        this.alerts = [];
    };
    return MessageService;
}());
MessageService = __decorate([
    core_1.Injectable()
], MessageService);
exports.MessageService = MessageService;
var MessageModel = (function () {
    function MessageModel(type, message) {
        if (type == 'E')
            type = 'danger';
        else if (type == 'S')
            type = 'success';
        this.type = type;
        this.msg = message;
    }
    return MessageModel;
}());
exports.MessageModel = MessageModel;
//# sourceMappingURL=message.service.js.map