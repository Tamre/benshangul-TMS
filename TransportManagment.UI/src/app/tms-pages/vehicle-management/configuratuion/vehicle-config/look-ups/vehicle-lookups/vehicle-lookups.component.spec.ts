import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleLookupsComponent } from './vehicle-lookups.component';

describe('VehicleLookupsComponent', () => {
  let component: VehicleLookupsComponent;
  let fixture: ComponentFixture<VehicleLookupsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VehicleLookupsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VehicleLookupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
