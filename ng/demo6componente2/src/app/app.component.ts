import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DadoComponent } from "./dado/dado.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, DadoComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  
  valor1: number = this.retornaAleatorio();
  valor2: number = this.retornaAleatorio();
  valor3: number = this.retornaAleatorio();
  resultado: string = '';

  retornaAleatorio()
  {
    return Math.floor(Math.random()*6) + 1;
  }


  random()
  {
    this.valor1  = this.retornaAleatorio();
    this.valor2  = this.retornaAleatorio();
    this.valor3  = this.retornaAleatorio();

    if(this.valor1 == this.valor2 && this.valor1 == this.valor3)
    {
      this.resultado = 'Gano';
    }
    else
    {
      this.resultado = 'Perdio';
    }

  }


}
