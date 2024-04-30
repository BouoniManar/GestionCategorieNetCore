using Microsoft.EntityFrameworkCore;

namespace App_TP2.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : 
           base(options)
 {
		}
		public DbSet<Categorie> categorie { get; set; }
		public DbSet<SousCategorie> souscategories { get; set; }
	}
}
