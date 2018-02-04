import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Injectable, Inject }     from '@angular/core';
import { Observable }     from 'rxjs/Observable';
import { HttpClient } from  '../../shared/httpclient/http-client.service';
import {Response} from '@angular/http';
import { ServiceRequest } from '../../shared/models/data-models.interface';

@Injectable()
export class ServiceRequestService {

    constructor(private httpClient: HttpClient) { }

    getServiceRequest(id: any): Observable<ServiceRequest> {
        return this.httpClient.get('serviceRequest?id=' + id)
            .map(this.extractData) 
            .catch(this.handleError);
    }

    getAllServiceRequests(): Observable<ServiceRequest[]> {
        return this.httpClient.get('serviceRequest')
            .map(this.extractData)
            .catch(this.handleError);
    }

    postServiceRequest(serviceRequest: any): Observable<ServiceRequest> {
        let body = JSON.stringify(ServiceRequest);
        return this.httpClient.post('serviceRequest/post',  body)
            .map(this.extractData)
            .catch(this.handleError);
    }


    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

}
