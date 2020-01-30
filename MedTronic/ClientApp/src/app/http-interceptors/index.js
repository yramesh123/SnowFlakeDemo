"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
/* "Barrel" of Http Interceptors */
var http_1 = require("@angular/common/http");
var genericinterceptor_1 = require("./genericinterceptor");
/** Http interceptor providers in outside-in order */
exports.httpInterceptorProviders = [
    { provide: http_1.HTTP_INTERCEPTORS, useClass: genericinterceptor_1.GenericInterceptor, multi: true },
];
//# sourceMappingURL=index.js.map