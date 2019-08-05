import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComicConfirmComponent } from './comic-confirm.component';

describe('ComicConfirmComponent', () => {
  let component: ComicConfirmComponent;
  let fixture: ComponentFixture<ComicConfirmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComicConfirmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComicConfirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
