namespace DatabaseSharding;

public class CreateUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string About { get; set; }
    public ShardNames ShardName { get; set; }
}

public enum ShardNames
{
    Master = 0,
    Shard1 = 1,
    Shard2 = 2
}
