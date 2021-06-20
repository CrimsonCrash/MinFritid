import { IaktivitetBrugerTilmeldt } from './IaktivitetBrugerTilmeldt';

export class Iaktivitet {
    // constructor
    // (
    //     AktivitetID: number,
    //     BrugerID: number,
    //     Titel: string,
    //     Beskrivelse: string,
    //     Huskeliste: string,
    //     Pris: number,
    //     MaxDeltagere: number,
    //     StartTidspunkt: Date,
    //     SlutTidspunkt: Date,
    //     PostNummer: number,
    //     AktivitetBrugerTilmeldte: IaktivitetBrugerTilmeldt[],
    //     Aktiv: boolean
    // )
    // {}
    AktivitetID: number;
    //BrugerID: number;
    Titel: string;
    Beskrivelse: string;
    Huskeliste: string;
    Pris: number;
    MaxDeltagere: number;
    StartTidspunkt: Date;
    SlutTidspunkt: Date;
    PostNummer: number;
    AktivitetBrugerTilmeldte: IaktivitetBrugerTilmeldt[];
    Aktiv: boolean;
}