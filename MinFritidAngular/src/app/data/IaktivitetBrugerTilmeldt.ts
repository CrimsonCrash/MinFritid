import { Iaktivitet } from "./Iaktivitet";
import { Ibruger } from "./Ibruger";

export class IaktivitetBrugerTilmeldt {
    constructor(
        _AktivitetID: number,
        _Aktivitet: Iaktivitet,
        _BrugerID: number,
        _Bruger: Ibruger
    ) {}
}
