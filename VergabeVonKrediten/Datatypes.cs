namespace VergabeVonKrediten.Datatypes;

public struct Kredit(float kredithöhe) {
    public float Kredithöhe { get; private set; } = kredithöhe;
    public float BezahlterBetrag { get; private set; }
    public bool Abbezahlt => BezahlterBetrag >= Kredithöhe;
}

public enum Kreditgrund {
    Autokauf,
    Hauskauf,
    Urlaub,
    Sonstiges
}

public enum Familienstand {
    ledig,
    verheiratet
}