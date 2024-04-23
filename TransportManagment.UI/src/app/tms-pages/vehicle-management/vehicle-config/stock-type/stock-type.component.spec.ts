import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockTypeComponent } from './stock-type.component';

describe('StockTypeComponent', () => {
  let component: StockTypeComponent;
  let fixture: ComponentFixture<StockTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StockTypeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StockTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
