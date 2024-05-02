import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlateStockComponent } from './plate-stock.component';

describe('PlateStockComponent', () => {
  let component: PlateStockComponent;
  let fixture: ComponentFixture<PlateStockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlateStockComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlateStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
