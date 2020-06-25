import { IaktivitetBrugerTilmeldt } from "./IaktivitetBrugerTilmeldt";

export class Ibruger {
    constructor(
        _BrugerID: number,
        _Fornavn: string,
        _Efternavn: string,
        _Foedselsdato: Date,
        _PostNummer: number,
        _Email: string,
        _UserName: string,
        _Password: string,
        _AktivitetBrugerTilmeldte: IaktivitetBrugerTilmeldt[],
        _Verificeret: boolean,
        _Aktiv: boolean
    ) {}
}
