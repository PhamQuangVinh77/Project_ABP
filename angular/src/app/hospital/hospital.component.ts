import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { HospitalDto } from '@proxy/dto/hospital-dtos';
import { HospitalService, HuyenService, TinhService, XaService } from '@proxy/services';

@Component({
  selector: 'app-hospital',
  templateUrl: './hospital.component.html',
  styleUrl: './hospital.component.scss',
  providers: [ListService]
})
export class HospitalComponent implements OnInit {
  hospital = { items: [], totalCount: 0 } as PagedResultDto<HospitalDto>;
  listTinh: any;
  listHuyen: any;
  listXa: any;
  maTinh: number = 0;
  maHuyen: number = 0;
  maXa: number = 0;
  skipCount: number = 0;
  maxResultCount: number = 10;
  filter: string = "";
  currentPage: number = 1;
  constructor(public readonly list: ListService, private bvService: HospitalService, private xaService: XaService, private tinhService: TinhService, private huyenService: HuyenService) {
  }
  ngOnInit(): void {
    this.getTinhsForSelect();
    const tinhStreamCreator = (query) => {
      query.skipCount = this.skipCount;
      query.maxResultCount = this.maxResultCount;
      query.filter = this.filter;
      query.maTinh = this.maTinh;
      query.maHuyen = this.maHuyen;
      query.maXa = this.maXa;
      return this.bvService.getList(query);
    };
    this.list.hookToQuery(tinhStreamCreator).subscribe((response) => {
      this.hospital = response;
    });
  }

  getTinhsForSelect(): void {
    this.tinhService.getAllTinhs().subscribe({
      next: (response: any) => {
        this.listTinh = response;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }

  getHuyensForSelect(maTinh: number): void {
    this.huyenService.getAllHuyensByMaTinh(maTinh).subscribe({
      next: (response: any) => {
        this.listHuyen = response;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }

  getXasForSelect(maTinh: number, maHuyen: number): void {
    this.xaService.getAllXasByMaTinhAndMaHuyen(maTinh, maHuyen).subscribe({
      next: (response: any) => {
        this.listXa = response;
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

  onTinhChange(tinh: number) {
    this.getHuyensForSelect(this.maTinh);
    this.listXa = [];
    this.maHuyen = 0;
    this.maXa = 0;
  }

  onHuyenChange(huyen: number) {
    this.getXasForSelect(this.maTinh, this.maHuyen);
    this.maXa = 0;
  }

  onXaChange(xa: number) {
    this.currentPage = 1;
    this.skipCount = 0;
    this.ngOnInit();
  }
}
