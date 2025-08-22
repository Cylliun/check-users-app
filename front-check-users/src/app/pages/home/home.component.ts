import { Component } from '@angular/core';
import { HeaderComponent } from '../../shared/components/header/header.component';

@Component({
  selector: 'app-home',
  imports: [HeaderComponent],
  template: `
    <app-header />
    <p>
      home works!
    </p>
  `,
  styles: ``
})
export class HomeComponent {

}
