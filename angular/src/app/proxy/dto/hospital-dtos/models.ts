import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateOrUpdateHospitalDto {
  ma: string;
  ten: string;
  maTinh: number;
  maHuyen: number;
  maXa: number;
  diaChi?: string;
}

export interface HospitalDto extends FullAuditedEntityDto<number> {
  ma?: string;
  ten?: string;
  maTinh: number;
  maHuyen: number;
  maXa: number;
  diaChi?: string;
}

export interface HospitalPagedAndSortedResultRequestDto extends PagedAndSortedResultRequestDto {
  maTinh?: number;
  maHuyen?: number;
  maXa?: number;
  filter?: string;
}
