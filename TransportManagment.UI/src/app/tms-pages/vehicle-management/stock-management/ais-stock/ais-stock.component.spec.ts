import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AisStockComponent } from './ais-stock.component';

describe('AisStockComponent', () => {
  let component: AisStockComponent;
  let fixture: ComponentFixture<AisStockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AisStockComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AisStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
