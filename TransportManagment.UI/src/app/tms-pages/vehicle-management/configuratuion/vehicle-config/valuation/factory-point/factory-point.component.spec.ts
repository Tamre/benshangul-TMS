import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FactoryPointComponent } from './factory-point.component';

describe('FactoryPointComponent', () => {
  let component: FactoryPointComponent;
  let fixture: ComponentFixture<FactoryPointComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FactoryPointComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FactoryPointComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
