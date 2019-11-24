import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {
  constructor(private _http: HttpClient) {
    this.getPokemon();
}
getPokemon(){
    let umbreon = this._http.get('https://pokeapi.co/api/v2/pokemon/197/');
    umbreon.subscribe(data => {
      console.log(data.name)
      console.log(`${data.name}'s hidden ability is ${data.abilities[0].ability.name}`)
      console.log("Got our pokemon!", data)
      let ability = this._http.get('https://pokeapi.co/api/v2/ability/inner-focus/');
      ability.subscribe(ability => {
        console.log(`${ability.pokemon.length} other pokemon share ${data.name}'s ability ${data.abilities[0].ability.name}`)
    })
    })
}
}