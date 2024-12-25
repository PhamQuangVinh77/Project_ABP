import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HuyenComponent } from './huyen.component';

const routes: Routes = [{ path: '', component: HuyenComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HuyenRoutingModule { }
