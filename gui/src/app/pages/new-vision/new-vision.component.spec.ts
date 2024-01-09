import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewVisionComponent } from './new-vision.component';

describe('NewVisionComponent', () => {
  let component: NewVisionComponent;
  let fixture: ComponentFixture<NewVisionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewVisionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewVisionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
