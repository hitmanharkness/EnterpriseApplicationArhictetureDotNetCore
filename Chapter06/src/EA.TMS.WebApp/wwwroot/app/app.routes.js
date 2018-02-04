"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var service_request_component_1 = require("./components/tenant/service-request.component");
var menu_component_1 = require("./menu.component");
//Routes Configuration
exports.routes = [
    { path: 'createServiceRequest', component: service_request_component_1.ServiceRequestComponent },
    { path: 'menu', component: menu_component_1.MenuComponent },
    {
        path: '',
        redirectTo: '/menu',
        pathMatch: 'full'
    },
];
exports.routing = router_1.RouterModule.forRoot(exports.routes);
//# sourceMappingURL=app.routes.js.map