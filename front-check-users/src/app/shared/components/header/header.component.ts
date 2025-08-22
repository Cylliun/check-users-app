import { Component, signal } from '@angular/core';
import { CheckinRoutingModule } from "../../../features/checkin/checkin-routing.module";

@Component({
  selector: 'app-header',
  imports: [CheckinRoutingModule],
  template: `
  <div class="flex justify-between items-center bg-bg-primary px-3 py-4 shadow-md">
    <h1 class="text-2xl text-text-primary">{{ title() }}</h1>

    <ul class="flex justify-center items-center gap-6 flex-1">
        <li><a class="text-sm text-text-primary" routerLink="/dashboard">Dashboard</a></li>
        <li><a class="text-sm text-text-primary" routerLink="/sobre-mim">About Me</a></li>
    </ul>
  </div>
  `,
  styles: ``
})
export class HeaderComponent {
  title = signal('CheckTwo')
}
