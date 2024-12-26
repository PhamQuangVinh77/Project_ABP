import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { XaComponent } from './xa.component';

const routes: Routes = [{ path: '', component: XaComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class XaRoutingModule { }
