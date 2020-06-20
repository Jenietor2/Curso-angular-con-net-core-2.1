import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  urlBase: string;
  constructor(private http: HttpClient, @Inject("BASE_URL") url: string) {
    this.urlBase = url;
  }

  getPersona() {
    return this.http.get(this.urlBase + "api/persona/Listadopersonas");
  }
  getPersonaFiltrada(nombre: string) {
    return this.http.get(this.urlBase + "api/persona/FiltradoPersona/" + nombre);
  }
  insertPersona(persona) {
    var url = this.urlBase + "api/persona/GuardarPersona";
    return this.http.post(url, persona);
  }
}
