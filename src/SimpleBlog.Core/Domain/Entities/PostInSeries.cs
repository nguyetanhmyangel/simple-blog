﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBlog.Core.Domain.Entities;

[Table("PostInSeries")]
[PrimaryKey(nameof(PostId), nameof(SeriesId))]

public class PostInSeries
{
    public Guid PostId { get; set; }
    public Guid SeriesId { get; set; }
    public int DisplayOrder { get; set; }
}
