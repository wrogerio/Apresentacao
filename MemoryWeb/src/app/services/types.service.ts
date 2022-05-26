import { Injectable } from '@angular/core';
import { Types } from '../interfaces/types';
import typesList from '../mock/types';

@Injectable({
  providedIn: 'root',
})
export class TypesService {
  constructor() {}

  getTypes(): Types[] {
    return typesList;
  }
}
