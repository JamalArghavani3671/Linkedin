using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace DatabaseSharding.Repositories;

public interface IBaseRepository<T> where T : class
{
    DbContext UnitOfWork { get; }
    Task<int> SaveContextAsync();
    Task<int> SaveContextAsync(CancellationToken cancellationToken);

    int SaveContext();
    IDbContextTransaction BeginTransaction();
    void Attach(T entity);

    IList<T> GetData(Expression<Func<T, bool>> filter = null,
                     Func<IQueryable<T>,
                     IOrderedQueryable<T>> orderBy = null,
                     List<Expression<Func<T, object>>> includeProperties = null,
                     bool noTrack = false);


    Task<IList<T>> GetDataAsync(Expression<Func<T, bool>> filter = null,
                                Func<IQueryable<T>,
                                IOrderedQueryable<T>> orderBy = null,
                                List<Expression<Func<T, object>>> includeProperties = null,
                                bool noTrack = false,
                                CancellationToken cancellationToken = default);


    Task<long> GetCountAsync(Expression<Func<T, bool>> filter = null, CancellationToken cancellationToken = default);

    void Insert(T entity);

    void Insert(IEnumerable<T> entitis);

    void Update(T entity);

    int Delete(long entityId);

    int Delete(T entity);
}
