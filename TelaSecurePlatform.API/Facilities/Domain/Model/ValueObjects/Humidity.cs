namespace TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

public record Humidity(int Actual, int Maximum, int Minimum, string Unit){
    public Humidity() : this(0, 0, 0, string.Empty) { }
}