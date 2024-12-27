import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateOrUpdateXaDto, XaDto, XaPagedAndSortedResultRequestDto } from '../dto/xa-dtos/models';

@Injectable({
  providedIn: 'root',
})
export class XaService {
  apiName = 'Default';
  

  create = (input: CreateOrUpdateXaDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, XaDto>({
      method: 'POST',
      url: '/api/app/xa',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/xa/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, XaDto>({
      method: 'GET',
      url: `/api/app/xa/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getAllXasByMaTinhAndMaHuyen = (maTinh: number, maHuyen: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, XaDto[]>({
      method: 'GET',
      url: '/api/app/xa/xas',
      params: { maTinh, maHuyen },
    },
    { apiName: this.apiName,...config });
  

  getList = (request: XaPagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<XaDto>>({
      method: 'GET',
      url: '/api/app/xa',
      params: { maTinh: request.maTinh, maHuyen: request.maHuyen, filter: request.filter, sorting: request.sorting, skipCount: request.skipCount, maxResultCount: request.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  importExcelByListXa = (listXa: XaDto[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/xa/import-excel',
      body: listXa,
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateOrUpdateXaDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, XaDto>({
      method: 'PUT',
      url: `/api/app/xa/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
