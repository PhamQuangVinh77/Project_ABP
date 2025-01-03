import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { XaDto } from '@proxy/dto/xa-dtos';
import { HuyenService, TinhService, XaService } from '@proxy/services';

@Component({
  selector: 'app-xa',
  templateUrl: './xa.component.html',
  styleUrl: './xa.component.scss',
  providers: [ListService]
})
export class XaComponent implements OnInit {
  xa = { items: [], totalCount: 0 } as PagedResultDto<XaDto>;
  selectedXa = {} as XaDto;

  listTinh: any;
  listHuyen: any;
  maTinh: number = 0;
  maHuyen: number = 0;
  listHuyenInForm: any;
  maTinhInForm: number = 0;
  maHuyenInForm: number = 0;
  skipCount: number = 0;
  maxResultCount: number = 10;
  filter: string = "";
  currentPage: number = 1;
  listAllXas: any[];
  changeForEdit: boolean = false;

  isModalOpen = false;
  form: FormGroup;
  constructor(public readonly list: ListService, private xaService: XaService, private tinhService: TinhService, private huyenService: HuyenService,
    private fb: FormBuilder, private confirmation: ConfirmationService) { }

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

  getHuyensForSelectInForm(maTinh: number): void {
    this.huyenService.getAllHuyensByMaTinh(maTinh).subscribe({
      next: (response: any) => {
        this.listHuyenInForm = response;
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
    this.maHuyen = 0;
  }

  onHuyenChange(huyen: number) {
    this.currentPage = 1;
    this.skipCount = 0;
    this.ngOnInit();
  }

  onTinhChangeInForm() {
    if(this.maTinhInForm == null) return;
    this.getHuyensForSelectInForm(this.maTinhInForm);
    if (this.changeForEdit) {
      this.changeForEdit = false;
      return;
    }
    this.maHuyenInForm = null;
  }

  importExcel() {
    this.xaService.getAllXasByMaTinhAndMaHuyen(this.maTinh, this.maHuyen).subscribe({
      next: (response: any) => {
        this.listAllXas = response;
        this.xaService.exportExcelByListXa(this.listAllXas).subscribe();
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
    });
  }

  createNewXa() {
    this.maTinhInForm = null;
    this.maHuyenInForm = null;
    this.selectedXa = {} as XaDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editXa(id: string) {
    this.xaService.get(id).subscribe((xa) => {
      this.maTinhInForm = xa.maTinh;
      this.maHuyenInForm = xa.maHuyen;
      this.selectedXa = xa;
      this.changeForEdit = true;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.getTinhsForSelect();
    this.form = this.fb.group({
      maXa: [this.selectedXa.maXa || '', Validators.required],
      tenXa: [this.selectedXa.tenXa || '', Validators.required],
      cap: [this.selectedXa.cap || '', Validators.required],
      maTinh: [this.maTinhInForm || '', Validators.required],
      maHuyen: [this.maHuyenInForm || '', Validators.required]
    });
    console.log(this.form);
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    if (this.selectedXa.id) {
      let request = {
        maXa: this.form.value.maXa,
        tenXa: this.form.value.tenXa,
        cap: this.form.value.cap,
        maTinh: this.form.value.maTinh,
        maHuyen: this.form.value.maHuyen,
      };
      this.xaService.update(this.selectedXa.id, request).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
    else {
      let request = {
        maXa: this.form.value.maXa,
        tenXa: this.form.value.tenXa,
        cap: this.form.value.cap,
        maTinh: this.form.value.maTinh,
        maHuyen: this.form.value.maHuyen,
      };
      this.xaService.create(request).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  deleteXa(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.xaService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
