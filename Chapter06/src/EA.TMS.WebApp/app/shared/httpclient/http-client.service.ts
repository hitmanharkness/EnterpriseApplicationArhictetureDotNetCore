
    import {Injectable, Inject} from '@angular/core';
    import {Http, Headers, RequestOptions, Response} from '@angular/http';
    import { Observable }     from 'rxjs/Observable';
    import { APP_CONFIG, AppConfig }    from '../../app.config';

    @Injectable()
    export class HttpClient {
        options;
        headers;
        apiEndpoint: string;

        constructor(private http: Http,
            @Inject(APP_CONFIG) config: AppConfig) {
            this.apiEndpoint = config.apiEndpoint;
        }
        /* this part is required if you are manullay sending the authrizatio  header
        createAuthorizationHeader(headers: Headers) {
            //this is for adding authorization header  
            headers.append('Authorization', 'Bearer ' + btoa('username:password'));
        }
        */

        get(url) {
            //here in each request called from components they tell me if this request is anonymous or not by type
            //if its not anynymous then i add the header other wise no. in your case browser will send the cookkie so you
            // dont need it
            this.headers = new Headers({ 'Content-Type': 'application/json' });

            /* this part is required if you are manullay sending the authrizatio  header
            if (type != 'anonymous')
                this.createAuthorizationHeader(this.headers);
            */
             this.options = new RequestOptions({ headers: this.headers });
       
            return this.http.get(this.apiEndpoint + url);
        }

        post(url, data) {
            this.headers = new Headers({ 'Content-Type': 'application/json' });
            this.options = new RequestOptions({ headers: this.headers });

            /* this part is required if you are manullay sending the authrizatio  header
            if (type != 'anonymous')
                this.createAuthorizationHeader(this.headers);
            */

            let options = new RequestOptions({ headers: this.headers, });
            return this.http.post(this.apiEndpoint + url, data, options);

        }
    }