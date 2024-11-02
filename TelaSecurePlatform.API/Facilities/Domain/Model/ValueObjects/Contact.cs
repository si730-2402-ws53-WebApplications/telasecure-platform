namespace TelaSecurePlatform.API.Facilities.Domain.Model.ValueObjects;

public record Contact(string Phone, string Email)
{
    public Contact() : this(string.Empty, string.Empty) { }
    
    //public Contact(string phone) : this(phone, string.Empty) { }
    //public string ContactInfo => $"{Phone} {Email}";
}