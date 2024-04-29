import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPeopleOnGroupComponent } from './add-people-on-group.component';

describe('AddPeopleOnGroupComponent', () => {
  let component: AddPeopleOnGroupComponent;
  let fixture: ComponentFixture<AddPeopleOnGroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddPeopleOnGroupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddPeopleOnGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
