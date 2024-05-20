import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VpaComponent } from './vpa.component';

describe('VpaComponent', () => {
  let component: VpaComponent;
  let fixture: ComponentFixture<VpaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VpaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VpaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
