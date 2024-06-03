using Microsoft.EntityFrameworkCore;

namespace JDChallenge.Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Employee> Employee { get; set; }
    
    public DbSet<Permission> Permissions { get; set; }

    public DbSet<PermissionType> PermissionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Permissions)
            .WithOne(p => p.Employee)
            .HasForeignKey(p => p.EmployeeId);

        modelBuilder.Entity<Permission>()
            .HasOne(p => p.PermissionType)
            .WithMany()
            .HasForeignKey(p => p.PermissionTypeId);

        modelBuilder.Entity<PermissionType>().HasData(
            new PermissionType
            {
                Id = 1,
                Name = "product.read",
                Description = "Description product.read",
                Created = DateTime.UtcNow
            },
            new PermissionType
            {
                Id = 2,
                Name = "product.write",
                Description = "Description product.write",
                Created = DateTime.UtcNow
            },
            new PermissionType
            {
                Id = 3,
                Name = "order.read",
                Description = "Description order.read",
                Created = DateTime.UtcNow
            },
            new PermissionType
            {
                Id = 4,
                Name = "order.write",
                Description = "Description order.write",
                Created = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "Ana",
                SurName = "Perez",
                Created = DateTime.UtcNow
            },
            new Employee
            {
                Id = 2,
                Name = "Dario",
                SurName = "Sanchez",
                Created = DateTime.UtcNow
            },
            new Employee
            {
                Id = 3,
                Name = "Diego",
                SurName = "Lopez",
                Created = DateTime.UtcNow
            }
        );
    }
}
