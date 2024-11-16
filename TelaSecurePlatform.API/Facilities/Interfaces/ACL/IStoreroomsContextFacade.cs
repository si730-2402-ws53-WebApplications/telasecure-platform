namespace TelaSecurePlatform.API.Facilities.Interfaces.ACL;

public interface IStoreroomsContextFacade
{
    Task<bool> IsIdValid(int storeroomId);
}