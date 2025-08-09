import { Component } from '@angular/core';

@Component({
  selector: 'app-dado',
  imports: [],
  templateUrl: './dado.component.html',
  styleUrl: './dado.component.css'
})
export class DadoComponent {

  varlor: number = Math.floor(Math.random() * 6) + 1;

}
