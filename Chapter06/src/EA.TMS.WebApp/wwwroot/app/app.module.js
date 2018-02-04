"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var common_1 = require("@angular/common");
var app_component_1 = require("./app.component");
var menu_component_1 = require("./menu.component");
var app_routes_1 = require("./app.routes");
var service_request_component_1 = require("./components/tenant/service-request.component");
var shared_module_1 = require("./shared/shared.module");
var app_config_1 = require("./app.config");
var forms_1 = require("@angular/forms");
var service_request_service_1 = require("./components/tenant/service-request.service");
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            app_routes_1.routing,
            shared_module_1.SharedModule,
            forms_1.FormsModule
        ],
        declarations: [
            app_component_1.AppComponent,
            service_request_component_1.ServiceRequestComponent,
            menu_component_1.MenuComponent
        ],
        bootstrap: [app_component_1.AppComponent],
        providers: [
            { provide: common_1.APP_BASE_HREF, useValue: '/' },
            { provide: app_config_1.APP_CONFIG, useValue: app_config_1.TMS_DI_CONFIG },
            service_request_service_1.ServiceRequestService
        ]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map