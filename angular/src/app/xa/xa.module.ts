import { NgModule } from '@angular/core';
import { XaRoutingModule } from './xa-routing.module';
import { XaComponent } from './xa.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzSelectModule } from 'ng-zorro-antd/select';


@NgModule({
  declarations: [
    XaComponent
  ],
  imports: [
    XaRoutingModule,
    SharedModule,
    FormsModule,
    NzButtonModule,
    NzIconModule,
    NzInputModule,
    NzTableModule,
    NzPaginationModule,
    NzGridModule,
    NzDividerModule,
    NzSelectModule
  ]
})
export class XaModule { }
