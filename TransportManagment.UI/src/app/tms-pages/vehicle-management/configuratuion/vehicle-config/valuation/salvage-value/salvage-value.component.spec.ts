import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalvageValueComponent } from './salvage-value.component';

describe('SalvageValueComponent', () => {
  let component: SalvageValueComponent;
  let fixture: ComponentFixture<SalvageValueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalvageValueComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SalvageValueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
