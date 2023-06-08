using ProF.Models;
using Microsoft.EntityFrameworkCore;


namespace ProF.Data
{
	public class ApplicationDBcontext : DbContext
    {

        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        { }
		public DbSet<comment> comments { get; set; }
		public DbSet<Registeration_USER_> Registeration_USER_s { get; set; }
	    public DbSet<login_admin> login_admins { get; set; }
        public DbSet<item> items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Cart> Carts { get; set; }
		public DbSet<Registeration_USER_> Registeration_USERS { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
        /*public DbSet<Category> Categorys { get; set; }*/
        /*public DbSet<Recipe> Recipes { get; set; }*/ 
        /*public DbSet<Search> Searches { get; set; }*/
        

    }
}
