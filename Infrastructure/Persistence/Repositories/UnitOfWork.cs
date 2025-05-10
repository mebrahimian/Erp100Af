using Erp100Af.Infrastructure.Persistence.App;
using Erp100Af.Infrastructure.Persistence.Repositories.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public ISegmentDefinitionRepository SegmentDefinitions { get; }

    public UnitOfWork(AppDbContext context, ISegmentDefinitionRepository segmentDefinitions)
    {
        _context = context;
        SegmentDefinitions = segmentDefinitions;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
