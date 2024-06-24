using BranchesLocatorAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BranchesLocatorAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Branch> Branches{ get; set; }
    }
}
