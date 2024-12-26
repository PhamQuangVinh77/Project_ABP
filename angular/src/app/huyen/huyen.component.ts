import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { HuyenDto } from '@proxy/dto/huyen-dtos';
import { HuyenService, TinhService } from '@proxy/services';

@Component({
  selector: 'app-huyen',
  templateUrl: './huyen.component.html',
  styleUrl: './huyen.component.scss',
  providers: [ListService]
})
export class HuyenComponent implements OnInit {
  huyen = { items: [], totalCount: 0 } as PagedResultDto<HuyenDto>;
  listTinh: any;
  skipCount: number = 0;
  maxResultCount: number = 10;
  filter: string = "";
  maTinh: number = 0;
  currentPage: number = 1;
  constructor(public readonly list: ListService, private huyenService: HuyenService, private tinhService: TinhService) { 
  }
  ngOnInit(): void {   
    this.getTinhsForSelect();
    const tinhStreamCreator = (query) => {
      query.skipCount = this.skipCount;
      query.maxResultCount = this.maxResultCount;
      query.filter = this.filter;
      query.maTinh = this.maTinh;
      return this.huyenService.getList(query);
    };
    this.list.hookToQuery(tinhStreamCreator).subscribe((response) => {
      this.huyen = response;
    });
  }

  getTinhsForSelect() : void{
    this.tinhService.getAllTinhs().subscribe({
      next: (response: any) => {
        this.listTinh = response;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }

  onPageChange(newPageIndex: number) {
    this.currentPage = newPageIndex;
    this.skipCount = this.maxResultCount * (this.currentPage - 1);
    this.ngOnInit();
  }

  onSearch() {
    this.currentPage = 1;
    this.skipCount = 0;
    this.ngOnInit();
  }

  onTinhChange(tinh: number){
    this.currentPage = 1;
    this.skipCount = 0;
    this.ngOnInit();
  }
}
