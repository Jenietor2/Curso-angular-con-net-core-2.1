import { Component, OnInit, Input } from '@angular/core';
import { ProductoServices } from '../../Servicios/producto.Services';

@Component({
  selector: 'tabla-producto',
  templateUrl: './tabla-producto.component.html'
})

export class TablaProductoComponent implements OnInit {
 @Input() productos: any;
  cabeceras: string[] = ["Id producto", "Nombre", "Precio", "Stock", "Categoria"];
  constructor(private productoServicio: ProductoServices) {
  }

  ngOnInit() {
    this.productoServicio.getProducto().subscribe(data => {
    this.productos = data
      console.log(data); });
  }

}
