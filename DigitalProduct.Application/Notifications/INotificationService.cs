using DigitalProduct.Application.Products.Dto;

namespace DigitalProduct.Application.Notifications;

public interface INotificationService
{
    void SendNotification(DetalleDto product);
}
