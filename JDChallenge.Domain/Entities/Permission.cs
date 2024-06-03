using System.ComponentModel.DataAnnotations.Schema;

namespace JDChallenge.Domain.Entities;

public class Permission : Entity
{
    public int EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
    public int PermissionTypeId { get; set; }
    public virtual PermissionType? PermissionType { get; set; }
    public DateTime ValidFrom {  get; set; }
    public DateTime ValidUntil { get; set; }
}
