using MemberJWTDemo;
using Microsoft.EntityFrameworkCore;

namespace WebApiCqrs.Data
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> options)
            : base(options)
        {

        }
        public DbSet<Member> Members { get; set; }
    }
}