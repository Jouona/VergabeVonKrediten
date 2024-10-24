namespace VergabeVonKrediten;

using VergabeVonKrediten.Datatypes;

public class Antrag {
    static readonly Dictionary<int, Kreditgrund> kreditgrundMapping = new Dictionary<int, Kreditgrund>() {
        { 1, Kreditgrund.Autokauf },
        { 2, Kreditgrund.Hauskauf },
        { 3, Kreditgrund.Urlaub },
        { 4, Kreditgrund.Sonstiges }
    };

    static readonly Dictionary<int, Familienstand> familienstandMapping = new Dictionary<int, Familienstand>() {
        { 1, Familienstand.ledig },
        { 2, Familienstand.verheiratet }
    };

    public PersonData Person { get; private set; }
    public Kreditgrund DerKreditgrund { get; private set; }
    public Familienstand DerFamilienstand { get; private set; }
    public float Kredithöhe { get; private set; }

    private Antrag() { } // private constructor to prevent direct instantiation

    public static Antrag? CreateAntrag(PersonData person, int kreditgrund, float kredit) {
        if (kreditgrundMapping.Count < kreditgrund) return null;

        int familienstand = person.Partner == null ? 1 : 2;

        return new Antrag() {
            Person = person,
            DerKreditgrund = kreditgrundMapping[kreditgrund],
            DerFamilienstand = familienstandMapping[familienstand],
            Kredithöhe = kredit
        };
    }
}