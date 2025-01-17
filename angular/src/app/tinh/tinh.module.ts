import { NgModule} from '@angular/core';
import { TinhRoutingModule } from './tinh-routing.module';
import { TinhComponent } from './tinh.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzDividerModule } from 'ng-zorro-antd/divider';

@NgModule({
  declarations: [
    TinhComponent
  ],
  imports: [
    TinhRoutingModule,
    SharedModule,
    FormsModule,
    NzButtonModule,
    NzIconModule,
    NzInputModule,
    NzTableModule,
    NzPaginationModule,
    NzGridModule,
    NzDividerModule
  ],
})
export class TinhModule { }
