import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BanBodyComponent } from './ban-body.component';

describe('BanBodyComponent', () => {
  let component: BanBodyComponent;
  let fixture: ComponentFixture<BanBodyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BanBodyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BanBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
