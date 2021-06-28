using Microsoft.EntityFrameworkCore;
using System;
using ViveVolar.Entities;

namespace ViveVolar.DataAccess
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<User> Users { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
          modelBuilder.Entity<User>().HasData(new User { Id=1,Login = "admin", Password = "5EKcto+c3SB88jbfBgGOqN2sO5VXAnZ2fhsTO66c77I=", Sal = "TQuWOAI0u13pwWG/nV2Wxg==" });


          modelBuilder.Ignore<Entity>();//Prevenir que no se creen una tablas entity
            base.OnModelCreating(modelBuilder);
        }
    }
}
