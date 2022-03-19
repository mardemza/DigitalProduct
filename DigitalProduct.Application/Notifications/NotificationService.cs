using DigitalProduct.Application.Generic;
using DigitalProduct.Application.Products.Dto;
using DigitalProduct.Core.Domain;

namespace DigitalProduct.Application.Notifications;

public class NotificationService : INotificationService
{
    private readonly IGenericRepository<Notification> _notificationRepository;

    public NotificationService(IGenericRepository<Notification> notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public void SendNotification(DetalleDto product)
    {
        _notificationRepository.Add(new Notification
        {
            Title = "Notificación de producto nuevo",
            Msg = $"Se agrego un nuevo producto: {product.Name}"
        });
    }
}
