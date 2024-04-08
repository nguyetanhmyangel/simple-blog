using SimpleBlog.Core.Repositories.Base;
using SimpleBlog.Infrastructure.Contexts;

namespace SimpleBlog.Infrastructure.Repositories.Base;
public class UnitOfWork : IUnitOfWork
{
    private readonly SimpleBlogDbContext _context;

    public UnitOfWork(SimpleBlogDbContext context)
    {
        _context = context;
        //Posts = new PostRepository(context, mapper, userManager);
        //PostCategories = new PostCategoryRepository(context, mapper);
        //Series = new SeriesRepository(context, mapper);
        //Transactions = new TransactionRepository(context, mapper);
        //Users = new UserRepository(context);
        //Tags = new TagRepository(context, mapper);
    }
    //public IPostRepository Posts { get; private set; }
    //public IPostCategoryRepository PostCategories { get; private set; }
    //public ISeriesRepository Series { get; private set; }
    //public ITransactionRepository Transactions { get; private set; }

    //public IUserRepository Users { get; private set; }
    //public ITagRepository Tags { get; private set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
