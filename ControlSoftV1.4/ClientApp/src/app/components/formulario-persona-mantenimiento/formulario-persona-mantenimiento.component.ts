import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { PersonaService } from '../../Servicios/persona.service';

@Component({
  selector: 'app-formulario-persona-mantenimiento',
  templateUrl: './formulario-persona-mantenimiento.component.html',
  styles: []
})
export class FormularioPersonaMantenimientoComponent implements OnInit {
  persona: FormGroup;
  constructor(private personaService: PersonaService) {
    this.persona = new FormGroup(
      {
        'idPersona': new FormControl("0"),
        'nombre': new FormControl("", [Validators.required, Validators.maxLength(100)]),
        'primerApellido': new FormControl("", [Validators.required, Validators.maxLength(150)]),
        'segundoApellido': new FormControl("", [Validators.required, Validators.maxLength(150)]),
        'telefono': new FormControl("", [Validators.required, Validators.maxLength(10)]),
        'correo': new FormControl("", [Validators.required, Validators.maxLength(100), Validators.pattern("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")])
      }
    ); 
  }

  ngOnInit() {
  }
  guardar() {
    if (this.persona.valid) {
      this.personaService.insertPersona(this.persona.value).subscribe(rsp => { });
    }
  }
}
