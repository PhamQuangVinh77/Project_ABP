import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TinhComponent } from './tinh.component';
import { authGuard, permissionGuard } from '@abp/ng.core';

const routes: Routes = [{ path: '', component: TinhComponent, canActivate: [authGuard, permissionGuard] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TinhRoutingModule { }
