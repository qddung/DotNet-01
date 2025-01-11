namespace FormProj.Models;

public class Service
{
    public Service()
    {

    }
    public Service(string name, int value)
    {
        Name = name;
        Value = value;
    }
    public string Name { get; set; }
    public int Value { get; set; }
}

public class Services
{

    public static List<Service> ListServices { get; set; } = new List<Service>(){
        new Service("Dịch vụ bảo hiểm", 1),
        new Service("Dịch vụ tư vấn", 2),
    };
}
public class CustomerContact
{
    [StringLength(100, "Full name must be at least 3 characters long.", 3)]
    public string FullName { get; set; }
    [Email(100, "Full name must be at least 3 characters long.", 3)]
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Message { get; set; }
    public int? ServiceId { get; set; } = 0;
}