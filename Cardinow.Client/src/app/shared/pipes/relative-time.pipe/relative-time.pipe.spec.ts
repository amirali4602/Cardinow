import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RelativeTimePipe } from './relative-time.pipe';

describe('RelativeTimePipe', () => {
  let component: RelativeTimePipe;
  let fixture: ComponentFixture<RelativeTimePipe>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RelativeTimePipe]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RelativeTimePipe);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
