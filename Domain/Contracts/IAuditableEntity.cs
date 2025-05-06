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

        string LastModifiedBy { get; set; }

        DateTime? LastModifiedOn { get; set; }
        public DateTime? RemovedTime { get; set; }
        public bool? IsRemoved { get; set; }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? RemovedBy { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string CompanyName { get; set; }
    }
}