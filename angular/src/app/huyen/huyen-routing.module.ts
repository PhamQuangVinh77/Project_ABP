import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HuyenComponent } from './huyen.component';
import { authGuard, permissionGuard } from '@abp/ng.core';

const routes: Routes = [{ path: '', component: HuyenComponent, canActivate: [authGuard, permissionGuard] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HuyenRoutingModule { }
