using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Redarbor.Domain.Entities;

namespace Redarbor.Infrastructure.Persistence;

public class RedarborDbContext : DbContext
{
    public RedarborDbContext(DbContextOptions<RedarborDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.Username).IsRequired();
        });

        modelBuilder.Entity<Employee>()
        .ToTable(tb => tb.HasTrigger("TR_Employees_Audit"));
    }
}