using Microsoft.EntityFrameworkCore;
using SimpleBlog.Core.Domain.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Core.Domain.Entities;

[Table("PostTags")]
[PrimaryKey(nameof(PostId), nameof(TagId))]

public class PostTag : AuditableEntity
{
    public Guid PostId { set; get; }
    public Guid TagId { set; get; }
}
