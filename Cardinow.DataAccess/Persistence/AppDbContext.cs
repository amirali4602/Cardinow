using Cardinow.Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cardinow.DataAccess.DbEntities;


namespace Cardinow.DataAccess.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<UserDbEntity> userDbEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Fluent API

    }
}
