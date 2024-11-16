using TelaSecurePlatform.API.Facilities.Domain.Model.Commands;
using TelaSecurePlatform.API.Facilities.Interfaces.REST.Resources;

namespace TelaSecurePlatform.API.Facilities.Interfaces.REST.Transform;

public class UpdateClimateSensorCommandFromResourceAssembler {
    public static UpdateClimateSensorCommand ToCommandFromResource(int Id, UpdateClimateSensorResource resource) {
        return new UpdateClimateSensorCommand(
            Id,
            resource.Name,
            resource.Model,
            resource.Type,
            resource.Image,
            resource.StoreRoomId);
    }
}