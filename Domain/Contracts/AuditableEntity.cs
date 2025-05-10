using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlazorApplication.Domain.Contracts
{
    public abstract class AuditableEntity<TId> : IAuditableEntity<TId>
    {
        public TId Id { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? RemovedTime { get; set; }
        public bool? IsRemoved { get; set; } = false ;
        public string? RemovedBy { get; set; }

        
        
    }
}