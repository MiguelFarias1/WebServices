using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs;

public class CategoryDTO
{
    public int CategoryId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string? ImageUrl { get; set; }
}
