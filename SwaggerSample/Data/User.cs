using Riolabs.PageDescriptor.Swashbuckle;
using Riolabs.PageDescriptor.Swashbuckle.Attributes.Fields;
using System.ComponentModel.DataAnnotations;

namespace SwaggerSample.Data;

public class User
{
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string FirstName { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string LastName { get; set; }

    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [DataType(DataType.Text)]
    [OptionsSimple("Woman", "Man", "Transgender", "Non-binary", "Not-respond")]
    public string Gender { get; set; }

    [DataType(DataType.Text)]
    [Options("<S> Single", "<M> Married", "<D> Divorced", "<W> Widowed", "<N> Not-respond", KeyName = "key", ValueName = "value")]
    public string MaritalStatus { get; set; }

    [DataType(DataType.Text)]
    [OptionsApi("/cars", "GET", "key", "value")]
    public string DrivenCar { get; set; }

    [FieldDefinitions("<GET> /cars")]
    public Dictionary<string, object> AdditionalProperty { get; set; }
}