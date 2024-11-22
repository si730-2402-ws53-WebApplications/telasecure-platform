using TelaSecurePlatform.API.Inventory.Domain.Model.Aggregates;
using TelaSecurePlatform.API.Shared.Domain.Repositories;

namespace TelaSecurePlatform.API.Inventory.Domain.Repositories;

public interface ICategoryRepository: IBaseRepository<Category>
{
    //agregar constrain para creacion de categorias
}