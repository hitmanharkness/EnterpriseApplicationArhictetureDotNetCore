"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var data_models_interface_1 = require("../../shared/models/data-models.interface");
var message_service_1 = require("../../shared/message/message.service");
var service_request_service_1 = require("./service-request.service");
var ServiceRequestComponent = (function () {
    function ServiceRequestComponent(messageService, serviceRequestService) {
        this.disable = false;
        this.message = messageService;
        this.serviceRequestService = serviceRequestService;
        messageService.clearMessages();
        this.serviceRequest = new data_models_interface_1.ServiceRequest();
    }
    ServiceRequestComponent.prototype.onSubmit = function () {
        var _this = this;
        this.serviceRequestService.postServiceRequest(this.serviceRequest)
            .subscribe(function () {
            (function (serviceReq) {
                return _this.message.pushMessage(new message_service_1.MessageModel('success', 'Service Request Submitted Successfully'));
            });
            //       // this.icon = "fa fa-2x fa-check-circle-o";
            //      //  this.isRequesting = false;
        }, function (error) {
            _this.message.pushMessage(new message_service_1.MessageModel('danger', 'Failed to submit ' + error));
            //      this.icon = "fa fa-2x fa-exclamation-circle";
            //   //     this.disable = "";
            //    //    this.isRequesting = false;
        });
    };
    return ServiceRequestComponent;
}());
ServiceRequestComponent = __decorate([
    core_1.Component({
        selector: 'createServiceRequest',
        templateUrl: 'Tenant/Create'
    }),
    __metadata("design:paramtypes", [message_service_1.MessageService, service_request_service_1.ServiceRequestService])
], ServiceRequestComponent);
exports.ServiceRequestComponent = ServiceRequestComponent;
//# sourceMappingURL=service-request.component.js.map