/**
 * Api
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 *//* tslint:disable:no-unused-variable member-ordering */

import { Inject, Injectable, Optional }                      from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,
         HttpResponse, HttpEvent }                           from '@angular/common/http';
import { CustomHttpUrlEncodingCodec }                        from '../encoder';

import { Observable }                                        from 'rxjs';

import { LibroEditInputModel } from '../model/libroEditInputModel';
import { LibroInputModel } from '../model/libroInputModel';
import { Response } from '../model/response';

import { BASE_PATH, COLLECTION_FORMATS }                     from '../variables';
import { Configuration }                                     from '../configuration';


@Injectable()
export class LibroService {

    protected basePath = '/';
    public defaultHeaders = new HttpHeaders();
    public configuration = new Configuration();

    constructor(protected httpClient: HttpClient, @Optional()@Inject(BASE_PATH) basePath: string, @Optional() configuration: Configuration) {
        if (basePath) {
            this.basePath = basePath;
        }
        if (configuration) {
            this.configuration = configuration;
            this.basePath = basePath || configuration.basePath || this.basePath;
        }
    }

    /**
     * @param consumes string[] mime-types
     * @return true: consumes contains 'multipart/form-data', false: otherwise
     */
    private canConsumeForm(consumes: string[]): boolean {
        const form = 'multipart/form-data';
        for (const consume of consumes) {
            if (form === consume) {
                return true;
            }
        }
        return false;
    }


    /**
     * 
     * 
     * @param searchValue 
     * @param skip 
     * @param take 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiLibroGet(searchValue?: string, skip?: number, take?: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiLibroGet(searchValue?: string, skip?: number, take?: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiLibroGet(searchValue?: string, skip?: number, take?: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiLibroGet(searchValue?: string, skip?: number, take?: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {




        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (searchValue !== undefined && searchValue !== null) {
            queryParameters = queryParameters.set('searchValue', <any>searchValue);
        }
        if (skip !== undefined && skip !== null) {
            queryParameters = queryParameters.set('skip', <any>skip);
        }
        if (take !== undefined && take !== null) {
            queryParameters = queryParameters.set('take', <any>take);
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('get',`${this.basePath}/api/Libro`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiLibroIdDelete(id: string, observe?: 'body', reportProgress?: boolean): Observable<Response>;
    public apiLibroIdDelete(id: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Response>>;
    public apiLibroIdDelete(id: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Response>>;
    public apiLibroIdDelete(id: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling apiLibroIdDelete.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
            'text/plain',
            'application/json',
            'text/json'
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<Response>('delete',`${this.basePath}/api/Libro/${encodeURIComponent(String(id))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param id 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiLibroIdGet(id: string, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiLibroIdGet(id: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiLibroIdGet(id: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiLibroIdGet(id: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling apiLibroIdGet.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('get',`${this.basePath}/api/Libro/${encodeURIComponent(String(id))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param body 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiLibroPatch(body?: LibroEditInputModel, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiLibroPatch(body?: LibroEditInputModel, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiLibroPatch(body?: LibroEditInputModel, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiLibroPatch(body?: LibroEditInputModel, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {


        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.request<any>('patch',`${this.basePath}/api/Libro`,
            {
                body: body,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param body 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiLibroPost(body?: LibroInputModel, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiLibroPost(body?: LibroInputModel, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiLibroPost(body?: LibroInputModel, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiLibroPost(body?: LibroInputModel, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {


        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.request<any>('post',`${this.basePath}/api/Libro`,
            {
                body: body,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     * 
     * 
     * @param idLibro 
     * @param idLibreria 
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public apiLibroRelacionarIdLibroIdLibreriaPost(idLibro: string, idLibreria: number, observe?: 'body', reportProgress?: boolean): Observable<any>;
    public apiLibroRelacionarIdLibroIdLibreriaPost(idLibro: string, idLibreria: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<any>>;
    public apiLibroRelacionarIdLibroIdLibreriaPost(idLibro: string, idLibreria: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<any>>;
    public apiLibroRelacionarIdLibroIdLibreriaPost(idLibro: string, idLibreria: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (idLibro === null || idLibro === undefined) {
            throw new Error('Required parameter idLibro was null or undefined when calling apiLibroRelacionarIdLibroIdLibreriaPost.');
        }

        if (idLibreria === null || idLibreria === undefined) {
            throw new Error('Required parameter idLibreria was null or undefined when calling apiLibroRelacionarIdLibroIdLibreriaPost.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
        ];

        return this.httpClient.request<any>('post',`${this.basePath}/api/Libro/relacionar/${encodeURIComponent(String(idLibro))}/${encodeURIComponent(String(idLibreria))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}
