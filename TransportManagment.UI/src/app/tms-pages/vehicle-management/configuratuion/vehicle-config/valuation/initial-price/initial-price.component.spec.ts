import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InitialPriceComponent } from './initial-price.component';

describe('InitialPriceComponent', () => {
  let component: InitialPriceComponent;
  let fixture: ComponentFixture<InitialPriceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InitialPriceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(InitialPriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
