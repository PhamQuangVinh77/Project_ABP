import { ComponentFixture, TestBed } from '@angular/core/testing';

import { XaComponent } from './xa.component';

describe('XaComponent', () => {
  let component: XaComponent;
  let fixture: ComponentFixture<XaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [XaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(XaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
