
using Getri_DFA_EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Getri_DFA_EntityFramework.EntityFramework;

public partial class GetridfaContext : DbContext
{
    public GetridfaContext()
    {
    }

    public GetridfaContext(DbContextOptions<GetridfaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }
}
