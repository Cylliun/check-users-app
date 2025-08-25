import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [],
  template: `
  <div class="flex flex-col justify-center items-center p-6">
    <div class="mb-4 p-4">
      <h1 class="text-xl text-center text-text-primary font-bold">Login Checkin</h1>
      <p class="text-center text-text-secondary font-normal">Sistema de controle de ponto</p>
    </div>
    <div class="flex flex-col gap-4 shadow-md rounded-lg p-4 bg-bg-primary">
      <div class="p-2">
        <h1 class="text-xl text-center text-text-primary font-bold">Acesso ao sistema</h1>
        <p class="text-center text-text-secondary font-normal">Use seu email corporativo e senha</p>
      </div>
    </div>
  </div>
  `,
  styles: ``
})
export class LoginComponent {

}
