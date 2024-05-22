import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignOwnersComponent } from './assign-owners.component';

describe('AssignOwnersComponent', () => {
  let component: AssignOwnersComponent;
  let fixture: ComponentFixture<AssignOwnersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssignOwnersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AssignOwnersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
