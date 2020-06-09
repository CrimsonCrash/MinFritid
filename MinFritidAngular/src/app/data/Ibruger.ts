import { IaktivitetBrugerTilmeldt } from './IaktivitetBrugerTilmeldt';

export class Ibruger {
    constructor
    (
        BrugerID: number,
        Fornavn: string,
        Efternavn: string,
        Foedselsdato: Date,
        PostNummer: number,
        Email: string,
        Password: string,
        AktivitetBrugerTilmeldte: IaktivitetBrugerTilmeldt[],
        Verificeret: boolean,
        Aktiv: boolean
    )
    {}
}