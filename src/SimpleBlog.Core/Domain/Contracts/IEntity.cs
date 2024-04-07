namespace SimpleBlog.Core.Domain.Contracts;

public interface IEntity
{
    public interface IEntity<TId> : IEntity
    {
        public TId Id { get; set; }
    }

    public interface IEntity
    {
    }
}
