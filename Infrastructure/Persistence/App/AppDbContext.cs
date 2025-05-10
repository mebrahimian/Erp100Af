using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Erp100Af.Domain.Entities.Accounting;
using Erp100Af.Domain.Entities;

namespace Erp100Af.Infrastructure.Persistence.App;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options) { }
    public DbSet<SegmentDefinition> SegmentDefinitions => Set<SegmentDefinition>();
    public DbSet<SegmentValue> SegmentValues => Set<SegmentValue>();
    public DbSet<CodeCombination> CodeCombinations => Set<CodeCombination>();
    public DbSet<CodeCombinationSegment> CodeCombinationSegments => Set<CodeCombinationSegment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CodeCombinationSegment>()
            .HasOne(x => x.CodeCombination)
            .WithMany(x => x.Segments)
            .HasForeignKey(x => x.CodeCombinationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CodeCombinationSegment>()
            .HasOne(x => x.SegmentDefinition)
            .WithMany()
            .HasForeignKey(x => x.SegmentDefinitionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CodeCombinationSegment>()
            .HasOne(x => x.SegmentValue)
            .WithMany()
            .HasForeignKey(x => x.SegmentValueId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}

