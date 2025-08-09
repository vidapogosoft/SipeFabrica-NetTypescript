import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  
  nombre = 'vidapogosot vpr';
  email = 'vidapogosot@gmail.com';
  sueldos = [1000,1200,1600];
  activo = false;

}
