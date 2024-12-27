import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateOrUpdateTinhDto, TinhDto, TinhPagedAndSortedResultRequestDto } from '../dto/tinh-dto/models';

@Injectable({
  providedIn: 'root',
})
export class TinhService {
  apiName = 'Default';
  

  create = (input: CreateOrUpdateTinhDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TinhDto>({
      method: 'POST',
      url: '/api/app/tinh',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/tinh/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TinhDto>({
      method: 'GET',
      url: `/api/app/tinh/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getAllTinhs = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, TinhDto[]>({
      method: 'GET',
      url: '/api/app/tinh/tinhs',
    },
    { apiName: this.apiName,...config });
  

  getList = (request: TinhPagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<TinhDto>>({
      method: 'GET',
      url: '/api/app/tinh',
      params: { filter: request.filter, sorting: request.sorting, skipCount: request.skipCount, maxResultCount: request.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  importExcelByListTinh = (listTinh: TinhDto[], config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/tinh/import-excel',
      body: listTinh,
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateOrUpdateTinhDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TinhDto>({
      method: 'PUT',
      url: `/api/app/tinh/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
