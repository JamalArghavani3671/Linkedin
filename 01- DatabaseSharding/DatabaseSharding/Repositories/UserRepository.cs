using DatabaseSharding.Context;
using DatabaseSharding.Entities;

namespace DatabaseSharding.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(LinkedinDbContext context) : base(context)
    {

    }
}