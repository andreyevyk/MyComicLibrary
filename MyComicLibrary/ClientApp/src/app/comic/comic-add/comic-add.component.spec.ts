import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComicAddComponent } from './comic-add.component';

describe('ComicAddComponent', () => {
  let component: ComicAddComponent;
  let fixture: ComponentFixture<ComicAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComicAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComicAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
