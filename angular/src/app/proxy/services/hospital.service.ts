import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { CreateOrUpdateHospitalDto, HospitalDto, HospitalPagedAndSortedResultRequestDto } from '../dto/hospital-dtos/models';

@Injectable({
  providedIn: 'root',
})
export class HospitalService {
  apiName = 'Default';
  

  create = (input: CreateOrUpdateHospitalDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, HospitalDto>({
      method: 'POST',
      url: '/api/app/hospital',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/hospital/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, HospitalDto>({
      method: 'GET',
      url: `/api/app/hospital/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getAllHospitalsByMaTinhAndMaHuyenAndMaXa = (maTinh: number, maHuyen: number, maXa: number, config?: Partial<Rest.Config>) =>
    this.restService.request<any, HospitalDto[]>({
      method: 'GET',
      url: '/api/app/hospital/hospitals',
      params: { maTinh, maHuyen, maXa },
    },
    { apiName: this.apiName,...config });
  

  getList = (request: HospitalPagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<HospitalDto>>({
      method: 'GET',
      url: '/api/app/hospital',
      params: { maTinh: request.maTinh, maHuyen: request.maHuyen, maXa: request.maXa, filter: request.filter, sorting: request.sorting, skipCount: request.skipCount, maxResultCount: request.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: number, input: CreateOrUpdateHospitalDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, HospitalDto>({
      method: 'PUT',
      url: `/api/app/hospital/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
