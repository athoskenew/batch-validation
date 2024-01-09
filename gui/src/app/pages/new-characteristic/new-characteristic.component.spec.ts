import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewCharacteristicComponent } from './new-characteristic.component';

describe('NewCharacteristicComponent', () => {
  let component: NewCharacteristicComponent;
  let fixture: ComponentFixture<NewCharacteristicComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewCharacteristicComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewCharacteristicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
