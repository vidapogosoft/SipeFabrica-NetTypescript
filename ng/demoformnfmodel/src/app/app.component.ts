import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  art = {codigo:0, descripcion: "", precio: 0}

  articulos = [{codigo: 1, descripcion: "computador memorria", precio: 21},
    {codigo: 2, descripcion: "computador memorria", precio: 25},
    {codigo: 3, descripcion: "computador memorria", precio: 22},
    {codigo: 4, descripcion: "computador memorria", precio: 26}
  ];

  hayregistros()
  {
    return this.articulos.length > 0;
  }

  borrar(codigo: number)
  {
      for (let x= 0; x < this.articulos.length; x++)
      {
          if (this.articulos[x].codigo == codigo)
          {
            this.articulos.splice(x,1);
            return;
          }
        
      } 
  }

  agregar()
  {
      if(this.art.codigo == 0)
      {
        alert ("Debe ingresar codigo de producto")
        return;
      }

      for (let x= 0; x < this.articulos.length; x++)
      {
        if (this.articulos[x].codigo == this.art.codigo)
        {
          alert ("codigo de producto ya existe")
        return;
        }
      }

      this.articulos.push({codigo: this.art.codigo, descripcion: this.art.descripcion, precio:this.art.precio});

      this.art.codigo = 0;
      this.art.descripcion = "";
      this.art.precio = 0;
  }

  modificar()
  {
    for (let x= 0; x < this.articulos.length; x++)
      {
          if (this.articulos[x].codigo == this.art.codigo)
          {
            this.articulos[x].descripcion = this.art.descripcion;
            this.articulos[x].precio = this.art.precio;
            
            
            return;

          }
          alert('No existe el codigo de articulo seleccionado')
        
         
      }

      
  }

  seleccionar( artparam: { codigo: number; descripcion: string; precio: number;})
  {
    this.art.codigo = artparam.codigo;
    this.art.descripcion = artparam.descripcion;
    this.art.precio = artparam.precio;
  }

}
