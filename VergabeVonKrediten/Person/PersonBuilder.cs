namespace VergabeVonKrediten.Person;

public class PersonBuilder {
    float einkommen;
    float vermögen;
    PersonData? partner;

    public PersonBuilder SetBaseData(float einkommen, float vermögen) {
        this.einkommen = einkommen;
        this.vermögen = vermögen;
        return this;
    }

    public PersonBuilder WithPartner(PersonData? partner) {
        this.partner = partner;
        return this;
    }

    public PersonData Build() => new PersonData(einkommen, vermögen, partner);
}