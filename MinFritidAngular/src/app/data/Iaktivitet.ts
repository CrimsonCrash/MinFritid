import { IaktivitetBrugerTilmeldt } from './IaktivitetBrugerTilmeldt';

export class Iaktivitet {
    constructor
    (
        AktivitetID: number,
        BrugerID: number,
        Titel: string,
        Beskrivelse: string,
        Huskeliste: string,
        Pris: number,
        MaxDeltagere: number,
        StartTidspunkt: Date,
        SlutTidspunkt: Date,
        PostNummer: number,
        AktivitetBrugerTilmeldte: IaktivitetBrugerTilmeldt[],
        Aktiv: boolean
    )
    {}
    // _AktivitetID: number;
    // _BrugerID: number;
    // _Titel: string;
    // _Beskrivelse: string;
    // _Huskeliste: string;
    // _Pris: number;
    // _MaxDeltagere: number;
    // _StartTidspunkt: Date;
    // _SlutTidspunkt: Date;
    // _PostNummer: number;
    // _AktivitetBrugerTilmeldte: IaktivitetBrugerTilmeldt[];
    // _Aktiv: boolean
}