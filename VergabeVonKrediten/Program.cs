using VergabeVonKrediten;

class Program {
    public static void Main(string[] args) {
       
        
        PersonData partner = new PersonData(500000000000f, 0f, null);
        PersonData testPerson = new PersonData(5000f, 500000f, partner);

        Antrag? antrag = Antrag.CreateAntrag(testPerson, 2, 50000000000f);
        
        KreditVergeber vergeber = new KreditVergeber(2);
        
        vergeber.KreditVergeben(antrag);
        partner.RemoveAllKredits();
        vergeber.KreditVergeben(antrag);
    }
}