using Convey.CQRS.Events;
using System.Threading.Tasks;

namespace Epilepsy_Health_App.Services.Identity.Application.Services
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
    }
}
