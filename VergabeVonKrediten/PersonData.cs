namespace VergabeVonKrediten;

using VergabeVonKrediten.Datatypes;

// wäre schöner hier vlt BuilderMethoden zu implementieren, insb für "freiwillige" Daten wie den Partner
public class PersonData {
    public bool Verheiratet => Partner != null;
    public float Einkommen { get; private set; }
    public float Vermögen { get; private set; }
    public PersonData? Partner { get; private set; }
    public bool Kreditwürdig => NichtAbbezahlteKredite() == 0;

    readonly List<Kredit> kredits = new();

    public PersonData(float einkommen, float vermögen, PersonData? partner) {
        Einkommen = einkommen;
        Vermögen = vermögen;
        Partner = partner;
        if (partner != null) {
            partner.Partner = this;
        }
    }

    public void AddKredit(Kredit kredit) => kredits.Add(kredit);
    public void RemoveAllKredits() => kredits.Clear();

    int NichtAbbezahlteKredite() {
        int count = 0;
        foreach (var kredit in kredits) {
            if (kredit.Abbezahlt) continue;
            count++;
        }

        return count;
    }
}