using VergabeVonKrediten;
using VergabeVonKrediten.Person;

class Program {
    public static void Main(string[] args) {
        PersonData partner = new PersonBuilder().SetBaseData(500000000000f, 0f).Build();
        PersonData testPerson = new PersonBuilder().SetBaseData(5000f, 500000f).WithPartner(partner).Build();

        Antrag? antrag = Antrag.CreateAntrag(testPerson, 2, 50000000000f);

        KreditVergeber vergeber = new KreditVergeber(2);

        vergeber.KreditVergeben(antrag);
        partner.RemoveAllKredits();
        vergeber.KreditVergeben(antrag);
    }
}