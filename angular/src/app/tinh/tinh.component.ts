import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TinhDto } from '@proxy/dto/tinh-dto';
import { TinhService } from '@proxy/services';

@Component({
  selector: 'app-tinh',
  templateUrl: './tinh.component.html',
  styleUrl: './tinh.component.scss',
  providers: [ListService]
})
export class TinhComponent implements OnInit {
  tinh = { items: [], totalCount: 0 } as PagedResultDto<TinhDto>;
  selectedTinh = {} as TinhDto;

  skipCount: number = 0;
  maxResultCount: number = 10;
  filter: string = "";
  currentPage: number = 1;
  listAllTinhs: any[];
  isModalOpen = false;
  form: FormGroup;
  constructor(public readonly list: ListService, private tinhService: TinhService, private fb: FormBuilder, private confirmation: ConfirmationService) { }
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

  importExcel() {
    this.tinhService.getAllTinhs().subscribe({
      next: (response: any) => {
        this.listAllTinhs = response;
        this.tinhService.importExcelByListTinh(this.listAllTinhs).subscribe();
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }

  createNewTinh() {
    this.selectedTinh = {} as TinhDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editTinh(id: string) {
    this.tinhService.get(id).subscribe((tinh) => {
      this.selectedTinh = tinh;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      maTinh: [this.selectedTinh.maTinh || '', Validators.required],
      tenTinh: [this.selectedTinh.tenTinh || '', Validators.required],
      cap: [this.selectedTinh.cap || '', Validators.required],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    if (this.selectedTinh.id) {
      let request = {
        maTinh: this.form.value.maTinh,
        tenTinh: this.form.value.tenTinh,
        cap: this.form.value.cap,
      };
      this.tinhService.update(this.selectedTinh.id, request).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
    else {
      let request = {
        maTinh: this.form.value.maTinh,
        tenTinh: this.form.value.tenTinh,
        cap: this.form.value.cap,
      };
      this.tinhService.create(request).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  deleteTinh(id: string) {
      this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
        if (status === Confirmation.Status.confirm) {
          this.tinhService.delete(id).subscribe(() => this.list.get());
        }
      });
    }
}
