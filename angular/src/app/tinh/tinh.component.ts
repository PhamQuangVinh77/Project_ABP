import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { TinhDto } from '@proxy/dto/tinh-dto';
import { TinhService } from '@proxy/services';

@Component({
  selector: 'app-tinh',
  templateUrl: './tinh.component.html',
  styleUrl: './tinh.component.scss',
  providers: [ListService]
})
export class TinhComponent implements OnInit{
  tinh = {items:[], totalCount: 0} as PagedResultDto<TinhDto>;
  skipCount : number = 0;
  maxResultCount : number = 10;
  filter : string = "";
  currentPage : number = 1;
  constructor(public readonly list: ListService, private tinhService: TinhService){}
  ngOnInit(): void {
    const tinhStreamCreator = (query) => {
      query.skipCount = this.skipCount;
      query.maxResultCount = this.maxResultCount;
      query.filter = this.filter;
      return this.tinhService.getList(query);
    };
    this.list.hookToQuery(tinhStreamCreator).subscribe((response) => {
      this.tinh = response;
    });
  } 

  onPageChange(newPageIndex: number){
    this.currentPage = newPageIndex;
    this.skipCount = this.maxResultCount*(this.currentPage-1);
    this.ngOnInit();
  }

  onSearch(){
    this.currentPage = 1;
    this.skipCount = 0;
    this.ngOnInit();
  }
}
