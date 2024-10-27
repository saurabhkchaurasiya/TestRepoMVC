using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using MVCWebApplication.Models;

namespace MVCWebApplication.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):base(option) 
        { }         
        public DbSet<People> peoples { get; set; }       
        
    }
}
