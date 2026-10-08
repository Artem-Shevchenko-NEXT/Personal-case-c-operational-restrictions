namespace Backend.Services;

public class OperationalRestrictionService : OperationalRestrictionService
{
    public CreateRestriction (data createRestrictionDto)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

    public EditRestriction(Guid Id, data updateRestrictionDto)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

    public ApproveRestriction(Guid Id, Guid approverId)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

    public DenyRestriction(Guid Id, Guid approverId, string reason)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

    public ArchiveRestriction(Guid Id)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

    public AssignOperator(Guid Id, Guid operatorId)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }
   
   public GetRestrictionById(Guid Id)
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }

     public List<OperationalRestriction> GetActiveRestrictions()
    {
        Console.WriteLine("ExampleService: received request from frontend");
        return true;
    }
}