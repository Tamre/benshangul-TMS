import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrcStockComponent } from './orc-stock.component';

describe('OrcStockComponent', () => {
  let component: OrcStockComponent;
  let fixture: ComponentFixture<OrcStockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrcStockComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OrcStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
