import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TinhComponent } from './tinh.component';

describe('TinhComponent', () => {
  let component: TinhComponent;
  let fixture: ComponentFixture<TinhComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TinhComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TinhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
