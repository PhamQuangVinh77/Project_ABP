import { NgModule } from '@angular/core';
import { HuyenRoutingModule } from './huyen-routing.module';
import { HuyenComponent } from './huyen.component';
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
import { NzFormModule } from 'ng-zorro-antd/form';


@NgModule({
  declarations: [
    HuyenComponent
  ],
  imports: [
    HuyenRoutingModule,
    SharedModule,
    FormsModule,
    NzButtonModule,
    NzIconModule,
    NzInputModule,
    NzTableModule,
    NzPaginationModule,
    NzGridModule,
    NzDividerModule,
    NzSelectModule,
    NzFormModule
  ]
})
export class HuyenModule { }
