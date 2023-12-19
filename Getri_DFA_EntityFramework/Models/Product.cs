using System.ComponentModel.DataAnnotations;

namespace Getri_DFA_EntityFramework.Models;

public partial class Product
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="Please enter product name")]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Required(ErrorMessage = "Please enter product price")]
    public decimal? Price { get; set; }

    public int? Quantity { get; set; }
}
