import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  selectedHuyen = {} as HuyenDto;
  listTinh: any;
  skipCount: number = 0;
  maxResultCount: number = 10;
  filter: string = "";
  maTinh: number = 0;
  maTinhInForm: number = 0;
  currentPage: number = 1;
  listAllHuyens: any[];

  isModalOpen = false;
  form: FormGroup;

  constructor(public readonly list: ListService, private huyenService: HuyenService, private tinhService: TinhService,
    private fb: FormBuilder, private confirmation: ConfirmationService) {
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
    this.currentPage = 1;
    this.skipCount = 0;
    this.ngOnInit();
  }

  importExcel() {
    this.huyenService.getAllHuyensByMaTinh(this.maTinh).subscribe({
      next: (response: any) => {
        this.listAllHuyens = response;
        this.huyenService.importExcelByListHuyen(this.listAllHuyens).subscribe();
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }

  createNewHuyen() {
    this.maTinhInForm = null;
    this.selectedHuyen = {} as HuyenDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editHuyen(id: string) {
    this.huyenService.get(id).subscribe((huyen) => {
      this.selectedHuyen = huyen;
      this.maTinhInForm = huyen.maTinh;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.getTinhsForSelect();
    this.form = this.fb.group({
      maHuyen: [this.selectedHuyen.maHuyen || '', Validators.required],
      tenHuyen: [this.selectedHuyen.tenHuyen || '', Validators.required],
      cap: [this.selectedHuyen.cap || '', Validators.required],
      maTinh: [this.maTinh || null, Validators.required],
    });
    console.log(this.form);
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    if (this.selectedHuyen.id) {
      let request = {
        maHuyen: this.form.value.maHuyen,
        tenHuyen: this.form.value.tenHuyen,
        cap: this.form.value.cap,
        maTinh: this.form.value.maTinh
      };
      this.huyenService.update(this.selectedHuyen.id, request).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
    else {
      let request = {
        maHuyen: this.form.value.maHuyen,
        tenHuyen: this.form.value.tenHuyen,
        cap: this.form.value.cap,
        maTinh: this.form.value.maTinh
      };
      this.huyenService.create(request).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  deleteHuyen(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.huyenService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
