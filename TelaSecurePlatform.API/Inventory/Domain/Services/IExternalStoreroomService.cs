namespace TelaSecurePlatform.API.Inventory.Domain.Services;

public interface IExternalStoreroomService
{
    Task<bool> IsStoreroomIdValid(int storeroomId);
}