namespace Backend.Services;

public class UserService : UserService
{
    public User Login(string Email, string PasswordHash)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

    public void Logout()
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

    public User CreateUser(userDataDto userData)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

    public void DeactivateUser(Guid Id)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

    public User GetUserById(Guid Id)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

    public List<User> GetActiveUser()
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }
}