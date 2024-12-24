import { NgModule} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TinhRoutingModule } from './tinh-routing.module';
import { TinhComponent } from './tinh.component';
import { SharedModule } from '../shared/shared.module';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';

@NgModule({
  declarations: [
    TinhComponent
  ],
  imports: [
    FormsModule,
    TinhRoutingModule,
    SharedModule,
    NzButtonModule,
    NzIconModule,
    NzInputModule,
    NzTableModule,
    NzPaginationModule
  ],
})
export class TinhModule { }
