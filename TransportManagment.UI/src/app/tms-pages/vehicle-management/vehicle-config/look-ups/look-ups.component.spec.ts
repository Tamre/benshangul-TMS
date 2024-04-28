import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LookUpsComponent } from './look-ups.component';

describe('LookUpsComponent', () => {
  let component: LookUpsComponent;
  let fixture: ComponentFixture<LookUpsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LookUpsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LookUpsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
