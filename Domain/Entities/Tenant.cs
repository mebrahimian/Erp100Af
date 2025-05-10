using MyBlazorApplication.Domain.Contracts;

namespace Erp100Af.Domain.Entities;
public class Tenant : AuditableEntity<int>
{
    public string Name { get; set; }             // مثلاً شرکت سامان تجارت
    public string Code { get; set; }             // مثلاً stco
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}