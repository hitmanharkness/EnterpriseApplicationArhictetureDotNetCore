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
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var core_1 = require("@angular/core");
var Observable_1 = require("rxjs/Observable");
var http_client_service_1 = require("../../shared/httpclient/http-client.service");
var data_models_interface_1 = require("../../shared/models/data-models.interface");
var ServiceRequestService = (function () {
    function ServiceRequestService(httpClient) {
        this.httpClient = httpClient;
    }
    ServiceRequestService.prototype.getServiceRequest = function (id) {
        return this.httpClient.get('serviceRequest?id=' + id)
            .map(this.extractData)
            .catch(this.handleError);
    };
    ServiceRequestService.prototype.getAllServiceRequests = function () {
        return this.httpClient.get('serviceRequest')
            .map(this.extractData)
            .catch(this.handleError);
    };
    ServiceRequestService.prototype.postServiceRequest = function (serviceRequest) {
        var body = JSON.stringify(data_models_interface_1.ServiceRequest);
        return this.httpClient.post('serviceRequest/post', body)
            .map(this.extractData)
            .catch(this.handleError);
    };
    ServiceRequestService.prototype.extractData = function (res) {
        var body = res.json();
        return body || {};
    };
    ServiceRequestService.prototype.handleError = function (error) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        var errMsg = (error.message) ? error.message :
            error.status ? error.status + " - " + error.statusText : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable_1.Observable.throw(errMsg);
    };
    return ServiceRequestService;
}());
ServiceRequestService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_client_service_1.HttpClient])
], ServiceRequestService);
exports.ServiceRequestService = ServiceRequestService;
//# sourceMappingURL=service-request.service.js.map