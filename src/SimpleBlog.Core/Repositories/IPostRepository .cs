using SimpleBlog.Core.Domain.Entities;
using SimpleBlog.Core.Dtos;
using SimpleBlog.Core.Dtos.Paged;
using SimpleBlog.Core.Repositories.Base;

namespace SimpleBlog.Core.Repositories;
public interface IPostRepository : IRepository<Post, Guid>
{
    Task<List<Post>> GetPopularPostsAsync(int count);
    Task<PagedResult<PostInListResponse>> GetPostsPagingAsync(string? keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
}
