import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceYearComponent } from './service-year.component';

describe('ServiceYearComponent', () => {
  let component: ServiceYearComponent;
  let fixture: ComponentFixture<ServiceYearComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ServiceYearComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ServiceYearComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
