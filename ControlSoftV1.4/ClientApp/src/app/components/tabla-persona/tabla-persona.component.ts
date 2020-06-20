import { Component, OnInit, Input } from '@angular/core';
import { PersonaService } from '../../Servicios/persona.service';

@Component({
  selector: 'tabla-persona',
  templateUrl: './tabla-persona.component.html',
  styles: []
})
export class TablaPersonaComponent implements OnInit {
  @Input() personas: any;
  @Input() isMantenimiento = false;
  encabezadosPersona = ["Id", "Nombre Completo", "Télefono", "Correo", "Fecha de nacimiento"];
  constructor(private personaServices: PersonaService) { }

  ngOnInit() {
    this.personaServices.getPersona().subscribe(rsp => { this.personas = rsp; console.log(rsp) })
  }

}
