using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context;

public class ApplicationContext : DbContext
{
    public DbSet<TravelRoute> TravelRoutes { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option) { }

}
