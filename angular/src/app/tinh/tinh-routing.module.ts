import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TinhComponent } from './tinh.component';

const routes: Routes = [{ path: '', component: TinhComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TinhRoutingModule { }
