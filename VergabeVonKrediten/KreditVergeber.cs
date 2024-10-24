using VergabeVonKrediten.Datatypes;
using VergabeVonKrediten.Validation;

namespace VergabeVonKrediten;

public class KreditVergeber(int anzahlKrediteZuVergeben) {
    int vergabeVonKrediten = anzahlKrediteZuVergeben;

    public bool KreditVergeben(Antrag? antrag) {
        if (antrag == null) {
            Console.WriteLine("Error with InitAntrag");
            return false;
        }

        if (vergabeVonKrediten > 0) {
            IAntragValidator validator = new DefaultValidator();
            if (validator.Validate(antrag)) {
                antrag.Person.AddKredit(new Kredit(antrag.Kredithöhe));
                Console.WriteLine("Antrag gewährt");
                vergabeVonKrediten--;
                return true;
            }
        }

        Console.WriteLine("Antrag abgelehnt");
        return false;
    }
}