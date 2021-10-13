using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Dtos.User;
using DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using Producer.Messages;

namespace Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserMessageSender _sender;
        private readonly IUserServices _userServices;

        public UserController(IUserMessageSender sender, IUserServices userServices)
        {
            _sender = sender;
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> Get(CancellationToken cancellationToken)
        {
            return await _userServices.GetUsers(cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult> Post(AddUserDto dto, CancellationToken cancellationToken)
        {
            await _userServices.AddUser(dto, cancellationToken);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateUserDto dto, CancellationToken cancellationToken)
        {
            await _sender.SendUpdateUser(dto, cancellationToken);
            return Ok();
        }
    }
}