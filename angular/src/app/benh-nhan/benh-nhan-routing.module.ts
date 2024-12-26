import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BenhNhanComponent } from './benh-nhan.component';

const routes: Routes = [{ path: '', component: BenhNhanComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BenhNhanRoutingModule { }
