import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateOrUpdateHuyenDto, HuyenDto } from '../dto/models';

@Injectable({
  providedIn: 'root',
})
export class HuyenService {
  apiName = 'Default';
  

  create = (input: CreateOrUpdateHuyenDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, HuyenDto>({
      method: 'POST',
      url: '/api/app/huyen',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/huyen/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, HuyenDto>({
      method: 'GET',
      url: `/api/app/huyen/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getAllHuyensByMaTinh = (maTinh: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, HuyenDto[]>({
      method: 'GET',
      url: '/api/app/huyen/huyens',
      params: { maTinh },
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<HuyenDto>>({
      method: 'GET',
      url: '/api/app/huyen',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateOrUpdateHuyenDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, HuyenDto>({
      method: 'PUT',
      url: `/api/app/huyen/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
