using VergabeVonKrediten.Datatypes;

namespace VergabeVonKrediten.Validation;

public class DefaultValidator : IAntragValidator {
    public bool Validate(Antrag antrag) {
        if (!ConfirmBaseRules(antrag)) {
            Console.WriteLine("Base rules are not valid.");
            return false;
        }

        if (antrag.Person.Verheiratet && !ConfirmMarriedRules(antrag)) {
            Console.WriteLine("Person married. Married rules are not valid.");
            return false;
        }

        if (!antrag.Person.Verheiratet && !ConfirmUnmarriedRules(antrag)) {
            Console.WriteLine("Person unmarried. Unmarried rules are not valid.");
            return false;
        }

        return true;
    }

    protected bool ConfirmBaseRules(Antrag antrag) =>
        antrag.Person.Kreditwürdig &&
        !(antrag.DerKreditgrund is Kreditgrund.Urlaub);


    protected bool ConfirmUnmarriedRules(Antrag antrag) =>
        !(antrag.Kredithöhe < antrag.Person.Einkommen * 10) &&
        !(antrag.Person.Vermögen < antrag.Kredithöhe);


    protected bool ConfirmMarriedRules(Antrag antrag) {
        return !(antrag.Kredithöhe > (antrag.Person.Einkommen + antrag.Person.Partner.Einkommen) * 10);
    }
}