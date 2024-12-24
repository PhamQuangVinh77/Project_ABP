import type { FullAuditedEntityDto } from '@abp/ng.core';

export interface BenhNhanDto extends FullAuditedEntityDto<number> {
  ma?: string;
  ten?: string;
  maTinh: number;
  maHuyen: number;
  maXa: number;
  diaChi?: string;
  hospitalId: number;
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

export interface CreateOrUpdateHospitalDto {
  ma: string;
  ten: string;
  maTinh: number;
  maHuyen: number;
  maXa: number;
  diaChi?: string;
}

export interface CreateOrUpdateHuyenDto {
  maHuyen: number;
  tenHuyen: string;
  cap: string;
  maTinh: number;
}

export interface CreateOrUpdateTinhDto {
  maTinh: number;
  tenTinh: string;
  cap: string;
}

export interface CreateOrUpdateXaDto {
  maXa: number;
  tenXa: string;
  cap: string;
  maTinh: number;
  maHuyen: number;
}

export interface HospitalDto extends FullAuditedEntityDto<number> {
  ma?: string;
  ten?: string;
  maTinh: number;
  maHuyen: number;
  maXa: number;
  diaChi?: string;
}

export interface HuyenDto extends FullAuditedEntityDto<string> {
  maHuyen: number;
  tenHuyen?: string;
  cap?: string;
  maTinh: number;
}

export interface TinhDto extends FullAuditedEntityDto<string> {
  maTinh: number;
  tenTinh?: string;
  cap?: string;
}

export interface XaDto extends FullAuditedEntityDto<string> {
  maXa: number;
  tenXa?: string;
  cap?: string;
  maTinh: number;
  maHuyen: number;
}
