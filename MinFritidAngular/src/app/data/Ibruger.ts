import { IaktivitetBrugerTilmeldt } from './IaktivitetBrugerTilmeldt';

export class Ibruger {
    // constructor
    // (
    //     _AktivitetID: number,
    //     _BrugerID: number,
    //     _Titel: string,
    //     _Beskrivelse: string,
    //     _Huskeliste: string,
    //     _Pris: number,
    //     _MaxDeltagere: number,
    //     _StartTidspunkt: Date,
    //     _SlutTidspunkt: Date,
    //     _PostNummer: number,
    //     _AktivitetBrugerTilmeldte: IaktivitetBrugerTilmeldt[],
    //     _Aktiv: boolean
    // )
    // {}
    
        BrugerID: number;
        Fornavn: string;
        Efternavn: string;
        Foedselsdato: Date;
        PostNummer: number;
        Email: string;
        Password: string;
        AktivitetBrugerTilmeldte: IaktivitetBrugerTilmeldt[];
        Verificeret: boolean;
        Aktiv: boolean;
}