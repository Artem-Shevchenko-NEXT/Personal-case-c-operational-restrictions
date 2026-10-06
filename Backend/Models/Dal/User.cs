namespace Backend.Models.Entities;

// MODEL - ENTITY (MVCS):
// Represents database tables managed and mapped by EF Core to PostgreSQL
public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public userRole Role { get; set; } = UserRole.Empty;

    public date Start_date { get; set; } = Date.Empty;

    public date End_date { get; set; } = Date.Empty;

    public userStatus User_status { get; set; } = userStatus.Empty;

    public workingStatus Working_status { get; set; } = workingStatus.Empty;
}
