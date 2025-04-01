using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }


}

