import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface BenhNhanDto extends FullAuditedEntityDto<number> {
  ma?: string;
  ten?: string;
  maTinh: number;
  maHuyen: number;
  maXa: number;
  diaChi?: string;
  hospitalId: number;
}

export interface BenhNhanPagedAndSortedResultRequestDto extends PagedAndSortedResultRequestDto {
  hospitalId?: number;
  filter?: string;
}

export interface CreateOrUpdateBenhNhanDto {
  ma: string;
  ten: string;
  maTinh: number;
  maHuyen: number;
  maXa: number;
  diaChi?: string;
  hospitalId: number;
}
