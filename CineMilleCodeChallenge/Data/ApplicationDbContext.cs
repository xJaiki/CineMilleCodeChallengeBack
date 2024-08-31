using Microsoft.EntityFrameworkCore;
using CineMilleCodeChallenge.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CineMilleCodeChallenge.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
