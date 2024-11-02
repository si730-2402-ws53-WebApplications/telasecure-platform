namespace TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

public record Temperature(int Actual, int Maximum, int Minimum, string Unit){
    public Temperature() : this(0, 0, 0, string.Empty) { }
}