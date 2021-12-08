export interface LibroViewModel {
    id: string;
    nombre: string;
    autor: string;
    noPaginas: number;
}
export interface GridLibrosViewModel{
    data:LibroViewModel[];
    totalCount:number;
}