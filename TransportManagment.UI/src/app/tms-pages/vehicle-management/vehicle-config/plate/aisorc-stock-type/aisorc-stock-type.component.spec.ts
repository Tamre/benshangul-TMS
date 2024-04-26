import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AisorcStockTypeComponent } from './aisorc-stock-type.component';

describe('AisorcStockTypeComponent', () => {
  let component: AisorcStockTypeComponent;
  let fixture: ComponentFixture<AisorcStockTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AisorcStockTypeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AisorcStockTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
