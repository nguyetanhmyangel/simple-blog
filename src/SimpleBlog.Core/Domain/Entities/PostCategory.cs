using Microsoft.EntityFrameworkCore;
using SimpleBlog.Core.Domain.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Core.Domain.Entities;

[Table("PostCategories")]
[Index(nameof(Slug), IsUnique = true)]
public class PostCategory : AuditableEntity<Guid>
{
    [MaxLength(250)]
    public required string Name { set; get; }

    [Column(TypeName = "varchar(250)")]
    public required string Slug { set; get; }

    public Guid? ParentId { set; get; }
    public bool IsActive { set; get; }

    [MaxLength(160)]
    public string? SeoDescription { set; get; }
    public int SortOrder { set; get; }
}
