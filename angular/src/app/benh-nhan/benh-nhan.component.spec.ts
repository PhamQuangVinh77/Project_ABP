import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BenhNhanComponent } from './benh-nhan.component';

describe('BenhNhanComponent', () => {
  let component: BenhNhanComponent;
  let fixture: ComponentFixture<BenhNhanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BenhNhanComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BenhNhanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
