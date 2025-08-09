import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  
  nombre = 'vidapogosot vpr';
  email = 'vidapogosot@gmail.com';
  sueldos = [1000,1200,1600];
  activo = true;
  

  esActivo()
  {
      if(this.activo)
      {
        return 'Persona Activa';
      }
      else
      {
        return 'Persona Inactiva';
      }
  }

  ultimosSueldos()
  {
    let suma = 0;

    for(let x=0; x< this.sueldos.length; x++)
    {
      suma+=this.sueldos[x];
    }

    return suma;
    
  }



}
