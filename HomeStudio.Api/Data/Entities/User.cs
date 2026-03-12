namespace HomeStudio.Api.Data.Entities;

public class User
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public Role Role { get; set; }
    public required string GoogleId {get; set; }
}

public enum Role
{
    Admin,
    User,
    Service
}


