import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateOrUpdateHuyenDto {
  maHuyen: number;
  tenHuyen: string;
  cap: string;
  maTinh: number;
}

export interface HuyenDto extends FullAuditedEntityDto<string> {
  maHuyen: number;
  tenHuyen?: string;
  cap?: string;
  maTinh: number;
}

export interface HuyenPagedAndSortedResultRequestDto extends PagedAndSortedResultRequestDto {
  maTinh?: number;
  filter?: string;
}
