namespace JDChallenge.Domain.Entities;

public class Employee : Entity
{
    public required string Name { get; set; }
    public required string SurName { get; set; }
    public ICollection<Permission> Permissions { get; } = [];
}
