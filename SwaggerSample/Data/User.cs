using Riolabs.PageDescriptor.Swashbuckle;
using Riolabs.PageDescriptor.Swashbuckle.Attributes.Fields;
using Riolabs.PageDescriptor.Swashbuckle.Attributes.Forms;
using System.ComponentModel.DataAnnotations;

namespace SwaggerSample.Data;

[CustomField("place-birth", "string", "")]
[CustomField("address", "string", "")]
public class User
{
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Sort(0)]
    public string FirstName { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Sort(1)]
    public string LastName { get; set; }

    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    [Required]
    [Sort(2)]
    public string Email { get; set; }

    [Classes("date-picker")]
    [DataType(DataType.Date)]
    [Sort(3)]
    public DateTime BirthDate { get; set; }

    [DataType(DataType.Text)]
    [OptionsSimple("Woman", "Man", "Transgender", "Non-binary", "Not-respond")]
    [Sort(4)]
    public string Gender { get; set; }

    [DataType(DataType.Text)]
    [Options("<S> Single", "<M> Married", "<D> Divorced", "<W> Widowed", "<N> Not-respond", KeyName = "key", ValueName = "value")]
    public string MaritalStatus { get; set; }

    [DataType(DataType.Text)]
    [OptionsApi("/cars", "GET", "key", "value")]
    public string DrivenCar { get; set; }
}