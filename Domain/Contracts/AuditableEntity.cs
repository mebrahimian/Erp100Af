using System;
using System.ComponentModel.DataAnnotations;

namespace MyBlazorApplication.Domain.Contracts
{
    public abstract class AuditableEntity<TId> : IAuditableEntity<TId>
    {
        public TId Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? RemovedTime { get; set; }
        public bool? IsRemoved { get; set; } = false ;
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public string? RemovedBy { get; set; }

#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }
    }
}