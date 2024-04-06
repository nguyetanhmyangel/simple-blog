﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Core.Domain.Entities;

[Table("PostTags")]
[PrimaryKey(nameof(PostId), nameof(TagId))]

public class PostTag
{
    public Guid PostId { set; get; }
    public Guid TagId { set; get; }
}
