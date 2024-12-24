import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { BenhNhanDto, CreateOrUpdateBenhNhanDto } from '../dto/models';

@Injectable({
  providedIn: 'root',
})
export class BenhNhanService {
  apiName = 'Default';
  

  create = (input: CreateOrUpdateBenhNhanDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BenhNhanDto>({
      method: 'POST',
      url: '/api/app/benh-nhan',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/benh-nhan/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BenhNhanDto>({
      method: 'GET',
      url: `/api/app/benh-nhan/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getAllBenhNhanByHospitalId = (hospitalId: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BenhNhanDto[]>({
      method: 'GET',
      url: `/api/app/benh-nhan/benh-nhan/${hospitalId}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<BenhNhanDto>>({
      method: 'GET',
      url: '/api/app/benh-nhan',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: number, input: CreateOrUpdateBenhNhanDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BenhNhanDto>({
      method: 'PUT',
      url: `/api/app/benh-nhan/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
