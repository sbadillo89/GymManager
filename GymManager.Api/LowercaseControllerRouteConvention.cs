using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace GymManager.Api
{
    public class LowercaseControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            // Convertir el nombre del controlador a minúsculas
            controller.ControllerName = controller.ControllerName.ToLowerInvariant();
        }
    }
}