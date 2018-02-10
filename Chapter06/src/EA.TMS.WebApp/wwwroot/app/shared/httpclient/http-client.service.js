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
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var app_config_1 = require("../../app.config");
var HttpClient = (function () {
    function HttpClient(http, config) {
        this.http = http;
        this.apiEndpoint = config.apiEndpoint;
    }
    /* this part is required if you are manullay sending the authrizatio  header
    createAuthorizationHeader(headers: Headers) {
        //this is for adding authorization header
        headers.append('Authorization', 'Bearer ' + btoa('username:password'));
    }
    */
    HttpClient.prototype.get = function (url) {
        //here in each request called from components they tell me if this request is anonymous or not by type
        //if its not anynymous then i add the header other wise no. in your case browser will send the cookkie so you
        // dont need it
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        /* this part is required if you are manullay sending the authrizatio  header
        if (type != 'anonymous')
            this.createAuthorizationHeader(this.headers);
        */
        this.options = new http_1.RequestOptions({ headers: this.headers });
        return this.http.get(this.apiEndpoint + url);
    };
    HttpClient.prototype.post = function (url, data) {
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        this.options = new http_1.RequestOptions({ headers: this.headers });
        /* this part is required if you are manullay sending the authrizatio  header
        if (type != 'anonymous')
            this.createAuthorizationHeader(this.headers);
        */
        var options = new http_1.RequestOptions({ headers: this.headers, });
        return this.http.post(this.apiEndpoint + url, data, options);
    };
    return HttpClient;
}());
HttpClient = __decorate([
    core_1.Injectable(),
    __param(1, core_1.Inject(app_config_1.APP_CONFIG)),
    __metadata("design:paramtypes", [http_1.Http, Object])
], HttpClient);
exports.HttpClient = HttpClient;
//# sourceMappingURL=http-client.service.js.map