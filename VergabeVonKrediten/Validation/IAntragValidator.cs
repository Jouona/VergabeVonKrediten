namespace VergabeVonKrediten.Validation;

public interface IAntragValidator {
    bool Validate(Antrag antrag);
}