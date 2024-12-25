import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CreateOrUpdateTinhDto {
  maTinh: number;
  tenTinh: string;
  cap: string;
}

export interface TinhDto extends FullAuditedEntityDto<string> {
  maTinh: number;
  tenTinh?: string;
  cap?: string;
}

export interface TinhPagedAndSortedResultRequestDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}
