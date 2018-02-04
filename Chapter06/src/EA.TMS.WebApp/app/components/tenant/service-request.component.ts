import { Component } from '@angular/core';
import { ServiceRequest } from '../../shared/models/data-models.interface'; 
import { MessageService, MessageModel } from '../../shared/message/message.service'; 
import { ServiceRequestService } from './service-request.service';

@Component
({
    selector: 'createServiceRequest',
    templateUrl: 'Tenant/Create'
})

export class ServiceRequestComponent {

    serviceRequest: ServiceRequest;
    disable = false;
    serviceRequestService: ServiceRequestService;
    message: MessageService;

    constructor(messageService: MessageService, serviceRequestService: ServiceRequestService
        ) {
        this.message = messageService;
        this.serviceRequestService = serviceRequestService;
        messageService.clearMessages();
        this.serviceRequest = new ServiceRequest();
    }
    
    onSubmit() {
           this.serviceRequestService.postServiceRequest(this.serviceRequest)
            .subscribe(() => {
                  serviceReq  =>
                  this.message.pushMessage(new MessageModel('success', 'Service Request Submitted Successfully'));
        //       // this.icon = "fa fa-2x fa-check-circle-o";
        //      //  this.isRequesting = false;
            },
            error => {
                 this.message.pushMessage(new MessageModel('danger', 'Failed to submit ' + error));
        //      this.icon = "fa fa-2x fa-exclamation-circle";
        //   //     this.disable = "";
        //    //    this.isRequesting = false;
            });
    }



}