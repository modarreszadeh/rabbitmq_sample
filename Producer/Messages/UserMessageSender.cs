using System.Threading;
using System.Threading.Tasks;
using DataAccess.Dtos.User;
using MassTransit;

namespace Producer.Messages
{
    public class UserMessageSender : IUserMessageSender
    {
        private readonly IPublishEndpoint _publishedEndpoint;

        public UserMessageSender(IPublishEndpoint publishedEndpoint)
        {
            _publishedEndpoint = publishedEndpoint;
        }

        public async Task SendUpdateUser(UpdateUserDto user, CancellationToken cancellationToken)
        {
            await _publishedEndpoint.Publish(message: user, cancellationToken);

            #region oldCode
            // var factory = new ConnectionFactory() { HostName = "localhost" };
            // using var connection = factory.CreateConnection();
            // using var channel = connection.CreateModel();
            // channel.QueueDeclare(queue: "aspnetcore",
            //     durable: false,
            //     exclusive: false,
            //     autoDelete: false,
            //     arguments: null);

            // string message = JsonConvert.SerializeObject(user);
            // var body = Encoding.UTF8.GetBytes(message);

            // channel.BasicPublish(exchange: "",
            //     routingKey: "aspnetcore",
            //     basicProperties: null,
            //     body: body);
            #endregion
        }
    }

    public interface IUserMessageSender
    {
        Task SendUpdateUser(UpdateUserDto user, CancellationToken cancellationToken);
    }
}