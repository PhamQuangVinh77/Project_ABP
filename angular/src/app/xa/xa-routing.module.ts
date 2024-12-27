import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { XaComponent } from './xa.component';
import { authGuard, permissionGuard } from '@abp/ng.core';

const routes: Routes = [{ path: '', component: XaComponent, canActivate: [authGuard, permissionGuard] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class XaRoutingModule { }
