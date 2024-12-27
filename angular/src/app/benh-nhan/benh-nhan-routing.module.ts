import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BenhNhanComponent } from './benh-nhan.component';
import { authGuard, permissionGuard } from '@abp/ng.core';

const routes: Routes = [{ path: '', component: BenhNhanComponent, canActivate: [authGuard, permissionGuard] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BenhNhanRoutingModule { }
