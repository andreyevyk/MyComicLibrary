
import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { MatSidenavModule } from '@angular/material/sidenav';
import { SidebarPageComponent } from './sidebar-page.component';

describe('SidebarPageComponent', () => {
  let component: SidebarPageComponent;
  let fixture: ComponentFixture<SidebarPageComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      imports: [MatSidenavModule],
      declarations: [SidebarPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SidebarPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
