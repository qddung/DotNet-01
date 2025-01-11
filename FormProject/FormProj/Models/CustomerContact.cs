using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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


// Create Custom Attribute
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
       AllowMultiple = false)]
public class ServiceValidationAttribute : ValidationAttribute
{
    public ServiceValidationAttribute()
            : base()
    { }
    public override bool IsValid(object? value)
    {
        var ErrorValue = new List<int?>() { null, 0 };
        int? v = (int?)value;
        return ErrorValue.Contains(v) == false;
    }
}

public class BooleanRequiredAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value != null && (bool)value == true;
    }
}

public class CustomerContact
{
    [StringLength(Int32.MaxValue, ErrorMessage = "Full name must be at least 3 characters long.", MinimumLength = 3)]
    public string FullName { get; set; } = "";

    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = "";

    [StringLength(12, ErrorMessage = "Phone number must be 10-12 digits.", MinimumLength = 10)]
    public string PhoneNumber { get; set; } = "";

    [Required(ErrorMessage = "Address can not empty")]
    public string Address { get; set; } = "";

    [StringLength(Int32.MaxValue, ErrorMessage = "Message must be at least 10 characters long.", MinimumLength = 10)]
    public string Message { get; set; } = "";

    [ServiceValidation(ErrorMessage = "Please select a service.")]
    public int ServiceId { get; set; } = 0;

    [BooleanRequired(ErrorMessage = "You must agree before submitting.")]
    public bool Agree { get; set; } = false;
}