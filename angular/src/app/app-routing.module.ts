import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () => import('@abp/ng.account').then(m => m.AccountModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@abp/ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'tenant-management',
    loadChildren: () =>
      import('@abp/ng.tenant-management').then(m => m.TenantManagementModule.forLazy()),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  { path: 'manage-tinh', loadChildren: () => import('./tinh/tinh.module').then(m => m.TinhModule) },
  { path: 'manage-huyen', loadChildren: () => import('./huyen/huyen.module').then(m => m.HuyenModule) },
  { path: 'manage-xa', loadChildren: () => import('./xa/xa.module').then(m => m.XaModule) },
  { path: 'manage-hospital', loadChildren: () => import('./hospital/hospital.module').then(m => m.HospitalModule) },
  { path: 'manage-benhNhan', loadChildren: () => import('./benh-nhan/benh-nhan.module').then(m => m.BenhNhanModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
