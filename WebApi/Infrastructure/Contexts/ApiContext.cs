using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<SubscribeEntity> Subscribers { get; set; }
    public DbSet<ContactEntity> Contacts { get; set; }
}