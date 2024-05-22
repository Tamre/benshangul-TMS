import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepreciatioCostComponent } from './depreciatio-cost.component';

describe('DepreciatioCostComponent', () => {
  let component: DepreciatioCostComponent;
  let fixture: ComponentFixture<DepreciatioCostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DepreciatioCostComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DepreciatioCostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
