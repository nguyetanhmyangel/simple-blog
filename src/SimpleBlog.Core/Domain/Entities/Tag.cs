using SimpleBlog.Core.Domain.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Core.Domain.Entities;

[Table("Tags")]
public class Tag : AuditableEntity<Guid>
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
}
