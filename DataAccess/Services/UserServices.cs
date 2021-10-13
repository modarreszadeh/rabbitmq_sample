using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Domains;
using DataAccess.Dtos.User;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services
{
    public class UserServices : IUserServices
    {
        private readonly RabbitMqDbContext _context;

        public UserServices(RabbitMqDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserViewModel>> GetUsers(CancellationToken cancellationToken)
        {
            return await _context.Users.Select(u => new UserViewModel
            {
                Password = u.Password,
                Username = u.Username
            }).ToListAsync(cancellationToken);
        }

        public async Task AddUser(AddUserDto dto, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = dto.Username,
                Password = dto.Password
            };
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateUser(UpdateUserDto dto, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == dto.Id, cancellationToken);
            user.Username = dto.Username;
            user.Password = dto.Password;
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public interface IUserServices
    {
        Task<List<UserViewModel>> GetUsers(CancellationToken cancellationToken);
        Task AddUser(AddUserDto dto, CancellationToken cancellationToken);
        Task UpdateUser(UpdateUserDto dto, CancellationToken cancellationToken);
    }

    public class UserViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AddUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}