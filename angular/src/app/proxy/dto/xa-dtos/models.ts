import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateOrUpdateXaDto {
  maXa: number;
  tenXa: string;
  cap: string;
  maTinh: number;
  maHuyen: number;
}

export interface XaDto extends FullAuditedEntityDto<string> {
  maXa: number;
  tenXa?: string;
  cap?: string;
  maTinh: number;
  maHuyen: number;
}

export interface XaPagedAndSortedResultRequestDto extends PagedAndSortedResultRequestDto {
  maTinh?: number;
  maHuyen?: number;
  filter?: string;
}
