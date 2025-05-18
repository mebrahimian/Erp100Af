using System;

namespace MyBlazorApplication.Domain.Contracts
{
    public interface IAuditableEntity<TId> : IAuditableEntity
    {
    }

    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }

        DateTime CreatedOn { get; set; }

        string? LastModifiedBy { get; set; }

        DateTime? LastModifiedOn { get; set; }
        public DateTime? RemovedTime { get; set; }
        public bool? IsRemoved { get; set; }
        public string? RemovedBy { get; set; }
        
    }
}