using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Entities;

namespace ViveVolar.DataAccess
{
    public interface IUserDbContext
    {
        Task<bool> Crear(User user);
        Task<bool> Login(User user);
        Task<User> ExisteUsuario(string login);
    }
    public class UserDbContext : IUserDbContext
    {
        DbSet<User> _user;
        ApiDbContext _ctx;
        public UserDbContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _user = ctx.Set<User>();
        }
        public async Task<bool> Crear(User user)
        {
            if(user.Id.Equals(0))
            {
                await _user.AddAsync(user);
            }
            else
            {
                _ctx.Entry(user).State = EntityState.Modified;
            }
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Login(User user)
        {
            User result = await _user
                    .Where(x => x.Login == user.Login)
                    .Where(x=>x.Password==user.Password)
                    .FirstOrDefaultAsync();
            if (result != null)
            {
                return true;
            }
            return false;
        }
        public async Task<User> ExisteUsuario(string login)
        {
            User result = await _user
                    .Where(x => x.Login == login)
                    .FirstOrDefaultAsync();
            return result;
        }
    }
}
