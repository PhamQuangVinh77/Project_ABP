import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { XaDto } from '@proxy/dto/xa-dtos';
import { HuyenService, TinhService, XaService } from '@proxy/services';

@Component({
  selector: 'app-xa',
  templateUrl: './xa.component.html',
  styleUrl: './xa.component.scss',
  providers: [ListService]
})
export class XaComponent implements OnInit{
  xa = { items: [], totalCount: 0 } as PagedResultDto<XaDto>;
    listTinh: any;
    listHuyen: any;
    maTinh: number = 0;
    maHuyen: number = 0;
    skipCount: number = 0;
    maxResultCount: number = 10;
    filter: string = "";
    currentPage: number = 1;
    constructor(public readonly list: ListService, private xaService: XaService, private tinhService: TinhService, private huyenService: HuyenService) { 
    }
    ngOnInit(): void {   
      this.getTinhsForSelect();
      const tinhStreamCreator = (query) => {
        query.skipCount = this.skipCount;
        query.maxResultCount = this.maxResultCount;
        query.filter = this.filter;
        query.maTinh = this.maTinh;
        query.maHuyen = this.maHuyen;
        return this.xaService.getList(query);
      };
      this.list.hookToQuery(tinhStreamCreator).subscribe((response) => {
        this.xa = response;
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

    getHuyensForSelect(maTinh: number) : void{
      this.huyenService.getAllHuyensByMaTinh(maTinh).subscribe({
        next: (response: any) => {
          this.listHuyen = response;
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
      this.getHuyensForSelect(this.maTinh);
    }
  
    onHuyenChange(huyen: number){
      this.currentPage = 1;
      this.skipCount = 0;
      this.ngOnInit();
    }


}
