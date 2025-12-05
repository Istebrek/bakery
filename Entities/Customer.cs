using System.ComponentModel.DataAnnotations;

namespace api.Entities;

public class Customer
{
    public int Id { get; set; }
    // [Required]
    // [StringLength(60)]
    public string Name { get; set; } = "";
    public int StoreNumber { get; set; }
    public string AddressLine { get; set; } = "";
    public string PostalCode { get; set; } = "";
    public string City { get; set; } = "";
}
