using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenCore.Domain.Tasks;
using OpenCore.Domain.Tasks.ValueObject;

namespace OpenCore.Infrastructure.Persistence.Tasks.Configuration;

internal sealed class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.ToTable("tasks");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasConversion(id => id.Value, value => TaskId.Create(value))
            .ValueGeneratedNever();

        builder.Property(t => t.Title)
            .HasMaxLength(TaskTitle.MaxLength)
            .IsRequired()
            .HasConversion(title => title.Value, value => TaskTitle.Create(value));

        builder.Property(t => t.CreatedAt).IsRequired();
    }
}
