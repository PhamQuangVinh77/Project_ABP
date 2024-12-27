import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BenhNhanDto } from '@proxy/dto/benh-nhan-dtos';
import { BenhNhanService, HospitalService, HuyenService, TinhService, XaService } from '@proxy/services';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-benh-nhan',
  templateUrl: './benh-nhan.component.html',
  styleUrl: './benh-nhan.component.scss',
  providers: [ListService]
})
export class BenhNhanComponent implements OnInit {
  benhNhan = { items: [], totalCount: 0 } as PagedResultDto<BenhNhanDto>;
  selectedBenhNhan = {} as BenhNhanDto;

  skipCount: number = 0;
  maxResultCount: number = 10;
  filter: string = "";
  currentPage: number = 1;
  listTinh: any;
  listHuyen: any;
  listXa: any;
  maTinh: number;
  maHuyen: number;
  maXa: number;
  changeForEdit: boolean = true;
  tenBenhVien: string;

  isModalOpen = false;
  form: FormGroup;

  constructor(public readonly list: ListService, private bnService: BenhNhanService, private fb: FormBuilder, private confirmation: ConfirmationService,
    private xaService: XaService, private tinhService: TinhService, private huyenService: HuyenService
  ) { }
  ngOnInit(): void {
    this.getTenBenhVien();
    const tinhStreamCreator = (query) => {
      query.skipCount = this.skipCount;
      query.maxResultCount = this.maxResultCount;
      query.filter = this.filter;
      return this.bnService.getList(query);
    };
    this.list.hookToQuery(tinhStreamCreator).subscribe((response) => {
      this.benhNhan = response;
    });
  }

  getTenBenhVien(): void{
    this.bnService.getHospitalNameByCurrentUser().subscribe({
      next: (response: any) => {
        this.tenBenhVien = response;
      },
      error: (error) => {
        console.error('Error fetching data:', error);
      }
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

  onTinhChange() {
    if (!this.changeForEdit || this.maTinh == null) return;
    this.getHuyensForSelect(this.maTinh);
    this.listXa = [];
    this.maHuyen = null;
    this.maXa = null;
  }

  onHuyenChange() {
    if (!this.changeForEdit){
      this.changeForEdit = true;
      return;
    }
    if (this.maTinh == null || this.maHuyen == null) return;
    this.getXasForSelect(this.maTinh, this.maHuyen);
    this.maXa = null;

  }

  createNewBenhNhan() {
    this.maTinh = null;
    this.maHuyen = null;
    this.maXa = null;
    this.selectedBenhNhan = {} as BenhNhanDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editBenhNhan(id: number) {
    this.bnService.get(id).subscribe((benhNhan) => {
      this.maTinh = benhNhan.maTinh;
      this.maHuyen = benhNhan.maHuyen;
      this.maXa = benhNhan.maXa;
      this.selectedBenhNhan = benhNhan;
      this.changeForEdit = false;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.getTinhsForSelect();
    if (!this.changeForEdit){
      this.getHuyensForSelect(this.maTinh);
      this.getXasForSelect(this.maTinh, this.maHuyen);
    }
    this.form = this.fb.group({
      ten: [this.selectedBenhNhan.ten || '', Validators.required],
      diaChi: [this.selectedBenhNhan.diaChi || '', Validators.required],
      tinh: [this.maTinh || null, Validators.required],
      huyen: [this.maHuyen || null, Validators.required],
      xa: [this.maXa || null, Validators.required],
    });
    console.log(this.form);
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    if (this.selectedBenhNhan.id) {
      let request = {
        ma: this.selectedBenhNhan.ma,
        ten: this.form.value.ten,
        diaChi: this.form.value.diaChi,
        maTinh: this.form.value.tinh,
        maHuyen: this.form.value.huyen,
        maXa: this.form.value.xa,
        hospitalId: this.selectedBenhNhan.hospitalId
      };
      this.bnService.update(this.selectedBenhNhan.id, request).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
    else {
      let request = {
        ma: "ma",
        ten: this.form.value.ten,
        diaChi: this.form.value.diaChi,
        maTinh: this.form.value.tinh,
        maHuyen: this.form.value.huyen,
        maXa: this.form.value.xa,
        hospitalId: 0
      };
      this.bnService.create(request).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  deleteBenhNhan(id: number) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.bnService.delete(id).subscribe(() => this.list.get());
      }
    });
  }
}
