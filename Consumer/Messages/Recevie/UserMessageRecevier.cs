using System.Threading.Tasks;
using DataAccess.Dtos.User;
using DataAccess.Services;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Consumer.Messages.Recevie
{
    public class UserMessageRecevier : IConsumer<UpdateUserDto>
    {
        private readonly ILogger<UserMessageRecevier> _logger;
        private readonly IUserServices _userServices;


        public UserMessageRecevier(ILogger<UserMessageRecevier> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }

        public async Task Consume(ConsumeContext<UpdateUserDto> context)
        {
            var user = new UpdateUserDto
            {
                Id = context.Message.Id,
                Username = context.Message.Username,
                Password = context.Message.Password
            };
            await _userServices.UpdateUser(user,context.CancellationToken);
            _logger.LogInformation($"log info user {context.Message.Id} | {context.Message.Username}");
        }
    }
}