using AutoMapper;
using SimpleBlog.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Core.Dtos;
public class PostInListResponse
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Slug { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public string? Thumbnail { get; set; }
    public int ViewCount { get; set; }
    public DateTime DateCreated { get; set; }

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Post, PostInListResponse>();
        }
    }
}
