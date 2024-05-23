import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlateTypeComponent } from './plate-type.component';

describe('PlateTypeComponent', () => {
  let component: PlateTypeComponent;
  let fixture: ComponentFixture<PlateTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PlateTypeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PlateTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
