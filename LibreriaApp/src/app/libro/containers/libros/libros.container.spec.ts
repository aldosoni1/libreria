import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibrosContainer } from './libros.container';

describe('LibrosContainer', () => {
  let component: LibrosContainer;
  let fixture: ComponentFixture<LibrosContainer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LibrosContainer ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LibrosContainer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
