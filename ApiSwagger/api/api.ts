export * from './libreria.service';
import { LibreriaService } from './libreria.service';
export * from './libro.service';
import { LibroService } from './libro.service';
export const APIS = [LibreriaService, LibroService];
