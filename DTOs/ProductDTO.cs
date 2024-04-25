using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs;

public class ProductDTO
{
    [Required]
    [StringLength(60)]
    public string Name { get; set; }
    [Required]
    [StringLength(300)]
    public string Description { get; set; }
    public decimal Price { get; set; }

    [Required, StringLength(3000)]
    public string ImageUrl { get; set; }
    public int CategoryId { get; set; }
}
