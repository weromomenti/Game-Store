export interface Game {
     id : number;
     PEGIRatingID: number;
     name : string;
     description: string;
     price : number;
     image : string;
     genreIds : number[];
     commentIds: number[];
}