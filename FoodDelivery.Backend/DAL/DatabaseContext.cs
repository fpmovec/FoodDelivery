using FoodDelivery.Backennd.BL.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FoodDelivery.Backennd.DAL;

public class DatabaseContext : DbContext
{
	public DatabaseContext() => Database.EnsureCreated();
	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
	public DbSet<UserDto> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder builder)
	{
		if (!builder.IsConfigured)
		{
            builder.UseSqlServer("Data Source=DESKTOP-MGC8JS3; Initial Catalog=FoodDelivery; Integrated Security=true; MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
	}
}