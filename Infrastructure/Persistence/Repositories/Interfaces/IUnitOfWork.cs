using Erp100Af.Infrastructure.Persistence.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ISegmentDefinitionRepository SegmentDefinitions { get; }

    Task<int> SaveChangesAsync();
}