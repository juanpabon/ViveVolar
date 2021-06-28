using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.DataAccess;
using ViveVolar.Entities;

namespace ViveVolar.Repository
{
    public interface IUserRepository
    {
        Task<bool> Crear(User user);
        Task<bool> Login(User user);
        Task<User> ExisteUsuario(string login);
    }
    public class UserRepository : IUserRepository
    {
        IUserDbContext _ctx;
        public UserRepository(IUserDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Crear(User user)
        {
            return await _ctx.Crear(user);
        }

        public async Task<bool> Login(User user)
        {
            return await _ctx.Login(user);
        }
        public async Task<User> ExisteUsuario(string login)
        {
            return await _ctx.ExisteUsuario(login);
        }

    }
}
