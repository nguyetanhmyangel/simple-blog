using SimpleBlog.Core.Domain.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Core.Domain.Entities;

[Table("PostActivityLogs")]
public class PostActivityLog : AuditableEntity<Guid>
{
    public Guid PostId { get; set; }

    public PostStatus FromStatus { set; get; }

    public PostStatus ToStatus { set; get; }

    public DateTime DateCreated { get; set; }

    [MaxLength(500)]
    public string? Note { set; get; }
}
