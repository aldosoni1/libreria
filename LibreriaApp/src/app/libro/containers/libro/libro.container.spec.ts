import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibroContainer } from './libro.container';

describe('LibroContainer', () => {
  let component: LibroContainer;
  let fixture: ComponentFixture<LibroContainer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LibroContainer ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LibroContainer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
