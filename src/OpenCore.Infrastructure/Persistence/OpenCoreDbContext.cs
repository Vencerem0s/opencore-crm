using Microsoft.EntityFrameworkCore;
using OpenCore.Application.Common.Interface;
using OpenCore.Domain.Tasks;

namespace OpenCore.Infrastructure.Persistence;

public sealed class OpenCoreDbContext(DbContextOptions<OpenCoreDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OpenCoreDbContext).Assembly);
    }
}
